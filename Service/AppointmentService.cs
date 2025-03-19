using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal class AppointmentService
    {
        public static Dictionary<DateOnly, Dictionary<TimeOnly, TimeSpan>> AppointmentDates = new();
        public static Dictionary<TimeOnly, string> BusinessHours = new();
        public static List<Appointment> Appointments;
        private static int highestID = 0;
        public static DateOnly selectedDate;

        //private static TimeZoneInfo est;
        //private static DateTime startEST;
        //private static DateTime endEST;

        public static void LoadAppointmentData(ViewAppointments view)
        {
            string sql = "SELECT appointment.appointmentId AS 'Id', appointment.userId, user.userName AS 'User', " +
                "appointment.customerId, customer.customerName AS 'Customer', appointment.type AS 'Type', " +
                "appointment.start AS 'Date', appointment.end AS 'End Date', " +
                "TIME(appointment.start) AS 'Start Time', TIME(appointment.end) AS 'End Time' " +
                "FROM appointment " +
                "JOIN user ON user.userId = appointment.userId " +
                "JOIN customer ON customer.customerId = appointment.customerId " +
                "ORDER BY appointment.start;";

            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, DBConnection.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            view.dataGridView1.DataSource = dt;
            ReadAppointmentData(sql);
        }

        private static void ReadAppointmentData(string sql)
        {
            Appointments = [];
            AppointmentDates = [];
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Appointment appointment = new
                    (
                        rdr.GetInt32("Id"),
                        rdr.GetInt32("userId"),
                        rdr.GetInt32("customerId"),
                        rdr.GetString("Type"),
                        rdr.GetDateTime("Date"),
                        rdr.GetDateTime("End Date")
                    );
                Appointments.Add(appointment);

                TimeSpan duration = appointment.EndTime.Subtract(appointment.StartTime);

                if (!AppointmentDates.ContainsKey(DateOnly.FromDateTime(appointment.StartTime)))
                {
                    AppointmentDates.Add(
                    DateOnly.FromDateTime(appointment.StartTime),
                    new Dictionary<TimeOnly, TimeSpan>
                        { { TimeOnly.FromDateTime(appointment.StartTime), duration } }
                    );
                }
                else
                {
                    AppointmentDates[DateOnly.FromDateTime(appointment.StartTime)].Add(TimeOnly.FromDateTime(appointment.StartTime), duration);
                }

                if (appointment.AppointmentId > highestID)
                {
                    highestID = appointment.AppointmentId;
                }
            }
            rdr.Close();
        }

        #region -- Methods to set available hours on AddAppointment form --
        public static void SetAvailableHours(AddAppointment view)
        {
            // Initialize the business hours dictionary
            InitializeBusinessHours();

            // Remove unavailable hours
            RemoveUnavailableHours(selectedDate);

            // Display available hours in the DataGridView
            DisplayHoursInDataGrid(view);
        }

        // Helper method to initialize business hours
        private static void InitializeBusinessHours()
        {
            BusinessHours.Clear();

            // Add all possible business hours in 30-minute increments
            for (int hour = 9; hour <= 16; hour++)
            {
                // Add the hour (e.g., 9:00 AM)
                BusinessHours.Add(
                    new TimeOnly(hour, 0, 0),
                    $"{(hour > 12 ? hour - 12 : hour)}:00 {(hour >= 12 ? "PM" : "AM")}"
                );

                // Add the half-hour (e.g., 9:30 AM)
                BusinessHours.Add(
                    new TimeOnly(hour, 30, 0),
                    $"{(hour > 12 ? hour - 12 : hour)}:30 {(hour >= 12 ? "PM" : "AM")}"
                );
            }
        }

        // Helper method to remove unavailable hours
        private static void RemoveUnavailableHours(DateOnly selectedDate)
        {
            // Clear hours if the selected date is in the past or a weekend
            if (selectedDate < DateOnly.FromDateTime(DateTime.Now) ||
                selectedDate.DayOfWeek == DayOfWeek.Saturday ||
                selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                BusinessHours.Clear();
                return;
            }

            // Remove hours that are in the past if the selected date is today
            if (selectedDate == DateOnly.FromDateTime(DateTime.Today))
            {
                var currentTime = TimeOnly.FromDateTime(DateTime.Now);
                var pastHours = BusinessHours.Keys.Where(time => time < currentTime).ToList();

                foreach (var hour in pastHours)
                {
                    BusinessHours.Remove(hour);
                }
            }

            // Remove hours that are already booked
            if (AppointmentDates.ContainsKey(selectedDate))
            {
                foreach (var appointment in AppointmentDates[selectedDate])
                {
                    TimeOnly appointmentTime = appointment.Key;
                    TimeSpan duration = appointment.Value;

                    // Remove the appointment time slot
                    BusinessHours.Remove(appointmentTime);

                    // If the appointment is 60 minutes, also remove the next time slot
                    if (duration.TotalMinutes == 60.0 && BusinessHours.ContainsKey(appointmentTime.AddMinutes(30)))
                    {
                        BusinessHours.Remove(appointmentTime.AddMinutes(30));
                    }
                }
            }
        }

        // Helper method to display hours in the DataGridView
        private static void DisplayHoursInDataGrid(AddAppointment view)
        {
            // Clear and set up the DataGridView
            view.hoursDGV.Columns.Clear();
            view.hoursDGV.Rows.Clear();
            view.hoursDGV.Columns.Add("Time", "Time");
            view.hoursDGV.CurrentCell = null;

            // Add available times to the DataGridView
            foreach (var entry in BusinessHours)
            {
                view.hoursDGV.Rows.Add(entry.Value);
            }
        }
        #endregion

        #region -- Methods to set available hours for ModifyAppointment form --
        // Overloaded method for modifying appointments
        public static void SetAvailableHours(ModifyAppointment modifyAppointment, TimeOnly start, int duration)
        {
            // Initialize the business hours dictionary
            InitializeBusinessHours();

            // Remove unavailable hours, but preserve the appointment being modified
            RemoveUnavailableHoursExceptCurrent(selectedDate, start, duration);

            // Display available hours in the DataGridView and select the start time
            DisplayHoursInDataGridWithSelection(modifyAppointment, start);
        }

        // Helper method to remove unavailable hours except for the current appointment being modified
        private static void RemoveUnavailableHoursExceptCurrent(DateOnly selectedDate, TimeOnly appointmentStartTime, int duration)
        {
            // Clear hours if the selected date is in the past or a weekend
            if (selectedDate < DateOnly.FromDateTime(DateTime.Now) ||
                selectedDate.DayOfWeek == DayOfWeek.Saturday ||
                selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                BusinessHours.Clear();
                return;
            }

            // Remove hours that are in the past if the selected date is today
            if (selectedDate == DateOnly.FromDateTime(DateTime.Today))
            {
                var currentTime = TimeOnly.FromDateTime(DateTime.Now);
                var pastHours = BusinessHours.Keys.Where(time => time < currentTime && time != appointmentStartTime).ToList();

                foreach (var hour in pastHours)
                {
                    BusinessHours.Remove(hour);
                }
            }

            // Remove hours that are already booked, except for the appointment being modified
            if (AppointmentDates.ContainsKey(selectedDate))
            {
                foreach (var appointment in AppointmentDates[selectedDate])
                {
                    TimeOnly existingAppointmentTime = appointment.Key;
                    TimeSpan existingDuration = appointment.Value;

                    // Skip the current appointment being modified
                    if (existingAppointmentTime == appointmentStartTime)
                        continue;

                    // Remove the appointment time slot
                    BusinessHours.Remove(existingAppointmentTime);

                    // If the appointment is 60 minutes, also remove the next time slot
                    if (existingDuration.TotalMinutes == 60.0 && BusinessHours.ContainsKey(existingAppointmentTime.AddMinutes(30)))
                    {
                        BusinessHours.Remove(existingAppointmentTime.AddMinutes(30));
                    }
                }
            }

            // Ensure the appointment start time is available in the dictionary
            // This handles the case where it might have been removed due to being in the past
            if (!BusinessHours.ContainsKey(appointmentStartTime))
            {
                string timeString = GetFormattedTimeString(appointmentStartTime);
                BusinessHours.Add(appointmentStartTime, timeString);
            }

            // If duration is 60 minutes, ensure the next slot is also available
            if (duration == 60)
            {
                TimeOnly nextSlot = appointmentStartTime.AddMinutes(30);
                if (!BusinessHours.ContainsKey(nextSlot))
                {
                    string timeString = GetFormattedTimeString(nextSlot);
                    BusinessHours.Add(nextSlot, timeString);
                }
            }
        }

        // Helper method to display hours in the DataGridView with a specific time selected
        private static void DisplayHoursInDataGridWithSelection(ModifyAppointment modifyAppointment, TimeOnly selectedTime)
        {
            // Clear and set up the DataGridView
            modifyAppointment.hoursDGV.Columns.Clear();
            modifyAppointment.hoursDGV.Rows.Clear();
            modifyAppointment.hoursDGV.Columns.Add("Time", "Time");

            // Sort the business hours for consistent display
            var sortedHours = BusinessHours.OrderBy(h => h.Key).ToDictionary(x => x.Key, x => x.Value);

            // Add available times to the DataGridView
            int selectedIndex = -1;
            int rowIndex = 0;

            foreach (var entry in sortedHours)
            {
                modifyAppointment.hoursDGV.Rows.Add(entry.Value);

                // Keep track of the row index for the selected time
                if (entry.Key == selectedTime)
                {
                    selectedIndex = rowIndex;
                }

                rowIndex++;
            }

            // Select the row corresponding to the appointment start time
            if (selectedIndex >= 0 && modifyAppointment.hoursDGV.Rows.Count > 0)
            {
                modifyAppointment.hoursDGV.ClearSelection();
                modifyAppointment.hoursDGV.Rows[selectedIndex].Selected = true;
                modifyAppointment.hoursDGV.CurrentCell = modifyAppointment.hoursDGV.Rows[selectedIndex].Cells[0];
            }
        }

        // Helper method to format a TimeOnly value into a display string
        private static string GetFormattedTimeString(TimeOnly time)
        {
            int hour = time.Hour;
            string amPm = hour >= 12 ? "PM" : "AM";
            int displayHour = hour > 12 ? hour - 12 : hour;
            return $"{displayHour}:{time.Minute:D2} {amPm}";
        }
        #endregion


        public static int GetBusinessHoursKeyIndex(TimeOnly key)
        {
            return BusinessHours.Keys.ToList().IndexOf(key);
        }

        public static void GetSelectedDate(string date)
        {
            selectedDate = DateOnly.FromDateTime(DateTime.Parse(date));
        }

        public static string GetSelectedTime(string selectedTime)
        {
            foreach (KeyValuePair<TimeOnly, string> time in BusinessHours)
            {
                if (time.Value == selectedTime)
                {
                    return time.Key.ToString();
                }
            }
            return null;
        }

        public static DateTime MergeDateTime(string date, string time)
        {
            return Convert.ToDateTime(date + " " + time);
        }

        public static void AddAppointment(AddAppointment addAppointment, string username)
        {
            if (addAppointment.hoursDGV.SelectedRows.Count == 0 || addAppointment.custNamesDGV.SelectedRows.Count == 0 || addAppointment.durationComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a start time, customer, and duration.");
                return;
            }


            int customerId = GetCustomerId(DBConnection.conn, addAppointment.custNamesDGV.CurrentRow.Cells[1].Value.ToString());
            DateTime selectedDate = addAppointment.monthCalendar.SelectionStart;
            DateTime startTime = DateTime.Parse(addAppointment.hoursDGV.SelectedRows[0].Cells[0].Value.ToString());
            DateTime start = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hour, startTime.Minute, 0);
            int duration = int.Parse(addAppointment.durationComboBox.SelectedItem.ToString().Substring(0, 2));
            DateTime end = start.AddMinutes(duration);

            if (!IsValidAppointmentTime(start, end))
            {
                MessageBox.Show("Appointment must be within business hours (9 AM - 5 PM EST, Mon-Fri).");
                return;
            }

            if (IsOverlappingAppointment(DBConnection.conn, customerId, start, end))
            {
                MessageBox.Show("Appointment conflicts with an existing appointment.");
                return;
            }

            string query = "INSERT INTO Appointment (appointmentId, customerId, userId, title, " +
                "description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, " +
                "@url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@appointmentId", GetNextAppointmentId(DBConnection.conn));
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@userId", GetUserId(DBConnection.conn, username));
            cmd.Parameters.AddWithValue("@title", "");
            cmd.Parameters.AddWithValue("@description", "");
            cmd.Parameters.AddWithValue("@location", "");
            cmd.Parameters.AddWithValue("@contact", "");
            cmd.Parameters.AddWithValue("@type", addAppointment.typeComboBox.Text);
            cmd.Parameters.AddWithValue("@url", "");
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@createDate", "2000-01-01");
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@lastUpdate", "2000-01-01");
            cmd.Parameters.AddWithValue("@lastUpdateBy", "");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appointment added successfully.");
            addAppointment.Close();
        }

        public static void ModifyAppointment(ModifyAppointment modifyAppointment, int appointmentId, int userId)
        {
            if (modifyAppointment.hoursDGV.SelectedRows.Count == 0 || modifyAppointment.custNamesDGV.SelectedRows.Count == 0 || modifyAppointment.durationComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a start time, customer, and duration.");
                return;
            }

            DateTime selectedDate = modifyAppointment.monthCalendar.SelectionStart;
            DateTime startTime = DateTime.Parse(modifyAppointment.hoursDGV.SelectedRows[0].Cells[0].Value.ToString());
            DateTime start = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hour, startTime.Minute, 0);
            int duration = int.Parse(modifyAppointment.durationComboBox.SelectedItem.ToString().Substring(0, 2));
            DateTime end = start.AddMinutes(duration);
            int customerId = Convert.ToInt32(modifyAppointment.custNamesDGV.SelectedRows[0].Cells[0].Value);

            string query = "UPDATE appointment SET appointmentId = @appointmentId, customerId = @customerId, userId = @userId, " +
                "title = @title, description = @description, location = @location, contact = @contact, type = @type, url = @url, " +
                "start = @start, end = @end, createDate = @createDate, createdBy = @createdBy, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy " +
                "WHERE appointmentId = @appointmentId";

            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@title", "");
            cmd.Parameters.AddWithValue("@description", "");
            cmd.Parameters.AddWithValue("@location", "");
            cmd.Parameters.AddWithValue("@contact", "");
            cmd.Parameters.AddWithValue("@type", modifyAppointment.typeComboBox.Text);
            cmd.Parameters.AddWithValue("@url", "");
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@lastUpdateBy", "");
            int rowsAffected = cmd.ExecuteNonQuery();

            MessageBox.Show(rowsAffected > 0 ? "Appointment updated successfully." : "No matching appointment found.");
            modifyAppointment.Close();
        }

        public static void DeleteAppointment(int appointmentID)
        {
            if (appointmentID == -1)
            {
                MessageBox.Show("Appointment not found.");
                return;
            }
            var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM appointment WHERE appointmentID = @id;";
                MySqlCommand cmd = new(deleteQuery, DBConnection.conn);
                cmd.Parameters.AddWithValue("@id", appointmentID);
                int rowsAffected = cmd.ExecuteNonQuery();

                MessageBox.Show(rowsAffected > 0 ? "Appointment deleted successfully." : "Appointment not found.");
            }
        }

        private static bool IsValidAppointmentTime(DateTime start, DateTime end)
        {
            //TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            //DateTime startEST = TimeZoneInfo.ConvertTime(start, est);
            //DateTime endEST = TimeZoneInfo.ConvertTime(end, est);

            //return startEST.TimeOfDay >= TimeSpan.FromHours(9) && endEST.TimeOfDay <= TimeSpan.FromHours(17) &&
            //       startEST.DayOfWeek != DayOfWeek.Saturday && startEST.DayOfWeek != DayOfWeek.Sunday;
            return start.TimeOfDay >= TimeSpan.FromHours(9) && end.TimeOfDay <= TimeSpan.FromHours(17) &&
                   start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday;
        }

        private static bool IsOverlappingAppointment(MySqlConnection connection, int customerId, DateTime start, DateTime end)
        {
            string query = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId AND ((start <= @end AND end >= @start))";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private static int GetCustomerId(MySqlConnection connection, string customerName)
        {
            string query = "SELECT customerId FROM customer WHERE customerName = @name";
            MySqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@name", customerName);
            object result = cmd.ExecuteScalar();
            return result is not null ? Convert.ToInt32(result) : -1;
        }

        private static int GetUserId(MySqlConnection connection, string username)
        {
            string query = "SELECT userId FROM user WHERE userName = @username";
            MySqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            object result = cmd.ExecuteScalar();
            return result is not null ? Convert.ToInt32(result) : -1;
        }

        private static int GetNextAppointmentId(MySqlConnection connection)
        {
            string query = "SELECT MAX(appointmentId) FROM appointment";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }
    }
}
