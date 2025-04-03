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
        public static DateTime justDate;

        public static void LoadAppointmentData(ViewAppointments view)
        {
            string sql = "SELECT appointment.appointmentId AS 'Id', appointment.userId, user.userName AS 'User', " +
                "appointment.customerId, customer.customerName AS 'Customer', appointment.type AS 'Type', " +
                "appointment.start AS 'Date', appointment.end AS 'End Date', " +
                "TIME(appointment.start) AS 'Start Time (EST)', TIME(appointment.end) AS 'End Time (EST)' " +
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
                    DateOnly key1 = DateOnly.FromDateTime(appointment.StartTime);
                    TimeOnly key2 = TimeOnly.FromDateTime(appointment.StartTime);
                    if (!AppointmentDates[key1].ContainsKey(key2))
                    {
                        AppointmentDates[key1].Add(TimeOnly.FromDateTime(appointment.StartTime), duration);
                    }
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
            InitializeBusinessHours();
            RemoveUnavailableHours(selectedDate);
            DisplayHoursInDataGrid(view);
        }

        private static void InitializeBusinessHours()
        {
            BusinessHours.Clear();
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            for (int hour = 9; hour <= 16; hour++)
            {
                DateTime estHour = new DateTime(1, 1, 1, hour, 0, 0);
                DateTime localHour = TimeZoneInfo.ConvertTime(estHour, estZone, localZone);
                BusinessHours.Add(
                    new TimeOnly(localHour.Hour, localHour.Minute, 0),
                    $"{localHour:hh:mm tt}"
                );

                DateTime estHalfHour = new DateTime(1, 1, 1, hour, 30, 0);
                DateTime localHalfHour = TimeZoneInfo.ConvertTime(estHalfHour, estZone, localZone);
                BusinessHours.Add(
                    new TimeOnly(localHalfHour.Hour, localHalfHour.Minute, 0),
                    $"{localHalfHour:hh:mm tt}"
                );
            }
        }

        private static void RemoveUnavailableHours(DateOnly selectedDate)
        {
            if (selectedDate < DateOnly.FromDateTime(DateTime.Now) ||
                selectedDate.DayOfWeek == DayOfWeek.Saturday ||
                selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                BusinessHours.Clear();
                return;
            }

            if (selectedDate == DateOnly.FromDateTime(DateTime.Today))
            {
                var currentTime = TimeOnly.FromDateTime(DateTime.Now);
                BusinessHours = BusinessHours.Where(kvp => kvp.Key >= currentTime).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            if (AppointmentDates.ContainsKey(selectedDate))
            {
                foreach (var appointment in AppointmentDates[selectedDate])
                {
                    DateTime estTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day,
                                                    appointment.Key.Hour, appointment.Key.Minute, 0);
                    DateTime localTime = ConvertFromEastern(estTime);
                    TimeOnly appointmentTime = TimeOnly.FromDateTime(localTime);
                    TimeSpan duration = appointment.Value;

                    BusinessHours.Remove(appointmentTime);

                    if (duration.TotalMinutes == 60.0 && BusinessHours.ContainsKey(appointmentTime.AddMinutes(30)))
                    {
                        BusinessHours.Remove(appointmentTime.AddMinutes(30));
                    }
                }
            }
        }

        private static void DisplayHoursInDataGrid(AddAppointment view)
        {
            view.hoursDGV.Columns.Clear();
            view.hoursDGV.Rows.Clear();
            view.hoursDGV.Columns.Add("Time", "Time");
            view.hoursDGV.CurrentCell = null;

            foreach (var entry in BusinessHours)
            {
                view.hoursDGV.Rows.Add(entry.Value);
            }
        }
        #endregion

        #region -- Methods to set available hours for ModifyAppointment form --
        public static void SetAvailableHours(ModifyAppointment view, TimeOnly startTime, int duration)
        {
            InitializeBusinessHours();
            RemoveUnavailableHoursExceptCurrent(selectedDate, ConvertTime(startTime), duration);
            DisplayHoursInDataGridWithSelection(ConvertTime(startTime), view);
        }

        private static TimeOnly ConvertTime(TimeOnly startTime)
        {
            DateTime estTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day,
                                            startTime.Hour, startTime.Minute, 0);
            DateTime localTime = ConvertFromEastern(estTime);
            TimeOnly appointmentStartTime = TimeOnly.FromDateTime(localTime);
            return appointmentStartTime;
        }

        private static void RemoveUnavailableHoursExceptCurrent(DateOnly selectedDate, TimeOnly startTime, int duration)
        {
            if (selectedDate < DateOnly.FromDateTime(DateTime.Now) ||
                selectedDate.DayOfWeek == DayOfWeek.Saturday ||
                selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                BusinessHours.Clear();
                return;
            }

            if (selectedDate == DateOnly.FromDateTime(DateTime.Today))
            {
                var currentTime = TimeOnly.FromDateTime(DateTime.Now);
                var pastHours = BusinessHours.Keys.Where(time => time < currentTime && time != startTime).ToList();

                foreach (var hour in pastHours)
                {
                    BusinessHours.Remove(hour);
                }
            }

            if (AppointmentDates.ContainsKey(selectedDate))
            {
                foreach (var appointment in AppointmentDates[selectedDate])
                {
                    TimeOnly bookedTimeLocal = ConvertTime(appointment.Key);
                    TimeSpan existingDuration = appointment.Value;

                    if (bookedTimeLocal == startTime)
                        continue;

                    BusinessHours.Remove(bookedTimeLocal);

                    if (existingDuration.TotalMinutes == 60.0 && BusinessHours.ContainsKey(bookedTimeLocal.AddMinutes(30)))
                    {
                        BusinessHours.Remove(bookedTimeLocal.AddMinutes(30));
                    }
                }
            }

            if (!BusinessHours.ContainsKey(startTime))
            {
                string timeString = GetFormattedTimeString(startTime);
                BusinessHours.Add(startTime, timeString);
            }
        }

        private static string GetFormattedTimeString(TimeOnly time)
        {
            int hour = time.Hour;
            string amPm = hour >= 12 ? "PM" : "AM";
            int displayHour = hour > 12 ? hour - 12 : hour;
            return $"{displayHour}:{time.Minute:D2} {amPm}";
        }

        private static void DisplayHoursInDataGridWithSelection(TimeOnly selectedTime, ModifyAppointment modifyAppointment)
        {
            modifyAppointment.hoursDGV.Columns.Clear();
            modifyAppointment.hoursDGV.Rows.Clear();
            modifyAppointment.hoursDGV.Columns.Add("Time", "Time");

            var sortedHours = BusinessHours.OrderBy(h => h.Key).ToDictionary(x => x.Key, x => x.Value);

            int selectedIndex = -1;
            int rowIndex = 0;

            foreach (var entry in sortedHours)
            {
                modifyAppointment.hoursDGV.Rows.Add(entry.Value);

                if (entry.Key == selectedTime)
                {
                    selectedIndex = rowIndex;
                }

                rowIndex++;
            }

            if (selectedIndex >= 0 && modifyAppointment.hoursDGV.Rows.Count > 0)
            {
                modifyAppointment.hoursDGV.ClearSelection();
                modifyAppointment.hoursDGV.Rows[selectedIndex].Selected = true;
                modifyAppointment.hoursDGV.CurrentCell = modifyAppointment.hoursDGV.Rows[selectedIndex].Cells[0];
            }
        }
        #endregion


        public static void GetSelectedDate(string date)
        {
            selectedDate = DateOnly.FromDateTime(DateTime.Parse(date));
            justDate = DateTime.Parse(date);
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
            int userId = GetUserId(DBConnection.conn, username);
            DateTime selectedDate = addAppointment.monthCalendar.SelectionStart;
            DateTime startTime = DateTime.Parse(addAppointment.hoursDGV.SelectedRows[0].Cells[0].Value.ToString());
            DateTime start = ConvertToEastern(new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hour, startTime.Minute, 0));
            int duration = int.Parse(addAppointment.durationComboBox.SelectedItem.ToString().Substring(0, 2));
            DateTime end = start.AddMinutes(duration);

            if (!IsValidAppointmentTime(start, end))
            {
                MessageBox.Show("Appointment must be within business hours (9 AM - 5 PM EST, Mon-Fri).");
                return;
            }

            if (IsOverlappingAppointmentForUser(DBConnection.conn, userId, start, end))
            {
                MessageBox.Show("You already have an appointment scheduled at this time.");
                return;
            }

            if (IsOverlappingAppointmentForCustomer(DBConnection.conn, customerId, start, end))
            {
                MessageBox.Show("This customer already has an appointment at this time.");
                return;
            }

            string query = "INSERT INTO Appointment (appointmentId, customerId, userId, title, " +
                "description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@appointmentId, @customerId, @userId, @title, @description, @location, @contact, @type, " +
                "@url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@appointmentId", GetNextAppointmentId(DBConnection.conn));
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@userId", userId);
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
            DateTime start = ConvertToEastern(new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hour, startTime.Minute, 0));
            int duration = int.Parse(modifyAppointment.durationComboBox.SelectedItem.ToString().Substring(0, 2));
            DateTime end = start.AddMinutes(duration);
            int customerId = Convert.ToInt32(modifyAppointment.custNamesDGV.SelectedRows[0].Cells[0].Value);

            if (!IsValidAppointmentTime(start, end))
            {
                MessageBox.Show("Appointment must be within business hours (9 AM - 5 PM EST, Mon-Fri).");
                return;
            }

            if (IsOverlappingAppointmentForUser(DBConnection.conn, userId, start, end, appointmentId))
            {
                MessageBox.Show("You already have an appointment scheduled at this time.");
                return;
            }

            if (IsOverlappingAppointmentForCustomer(DBConnection.conn, customerId, start, end, appointmentId))
            {
                MessageBox.Show("This customer already has an appointment at this time.");
                return;
            }

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
            return start.TimeOfDay >= TimeSpan.FromHours(9) && end.TimeOfDay <= TimeSpan.FromHours(17) &&
                   start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday;
        }

        //private static bool IsOverlappingAppointmentForUser(MySqlConnection connection, int userId, DateTime start, DateTime end)
        //{
        //    string query = "SELECT COUNT(*) FROM appointment WHERE userId = @userId AND ((start < @end AND end > @start))";
        //    MySqlCommand cmd = new MySqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@userId", userId);
        //    cmd.Parameters.AddWithValue("@start", start);
        //    cmd.Parameters.AddWithValue("@end", end);
        //    int count = Convert.ToInt32(cmd.ExecuteScalar());
        //    return count > 0;
        //}

        private static bool IsOverlappingAppointmentForUser(MySqlConnection connection, int userId, DateTime start, DateTime end, int? appointmentId = null)
        {
            // Query to check for overlapping appointments, but ignore the current one if we're updating
            string query = "SELECT COUNT(*) FROM appointment WHERE userId = @userId " +
                           "AND ((start < @end AND end > @start)) " +
                           "AND (@appointmentId IS NULL OR appointmentId != @appointmentId)";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);

            // If appointmentId is provided, use it; otherwise, ignore it
            if (appointmentId.HasValue)
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@appointmentId", DBNull.Value);
            }

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0; // True means there's an overlap
        }

        //private static bool IsOverlappingAppointmentForCustomer(MySqlConnection connection, int customerId, DateTime start, DateTime end)
        //{
        //    string query = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId AND ((start < @end AND end > @start))";
        //    MySqlCommand cmd = new MySqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@customerId", customerId);
        //    cmd.Parameters.AddWithValue("@start", start);
        //    cmd.Parameters.AddWithValue("@end", end);
        //    int count = Convert.ToInt32(cmd.ExecuteScalar());
        //    return count > 0;
        //}

        private static bool IsOverlappingAppointmentForCustomer(MySqlConnection connection, int customerId, DateTime start, DateTime end, int? appointmentId = null)
        {
            // Query to check for overlapping appointments, but ignore the current one if we're updating
            string query = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId " +
                           "AND ((start < @end AND end > @start)) " +
                           "AND (@appointmentId IS NULL OR appointmentId != @appointmentId)";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);

            // If appointmentId is provided, use it; otherwise, ignore it
            if (appointmentId.HasValue)
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@appointmentId", DBNull.Value);
            }

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0; // True means there's an overlap
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

        public static DateTime ConvertToEastern(DateTime localTime)
        {
            if (TimeZoneInfo.Local.StandardName != "Eastern Standard Time")
            {
                TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                bool isDST = estZone.IsDaylightSavingTime(justDate);
                if (isDST)
                {
                    localTime = localTime.AddHours(-1);
                }
                return TimeZoneInfo.ConvertTime(localTime, TimeZoneInfo.Local, estZone);
            }
            return localTime;
        }

        public static DateTime ConvertFromEastern(DateTime estTime)
        {
            if (TimeZoneInfo.Local.StandardName != "Eastern Standard Time")
            {
                TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                bool isDST = estZone.IsDaylightSavingTime(justDate);
                if (isDST)
                {
                    estTime = estTime.AddHours(1);
                }
                return TimeZoneInfo.ConvertTime(estTime, estZone, TimeZoneInfo.Local);
            }
            return estTime;
        }

        public static void CheckUpcomingAppointments(int userId)
        {
            string query = "SELECT start FROM appointment WHERE userId = @userId AND start BETWEEN @now AND @futureLimit ORDER BY start LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@now", ConvertToEastern(DateTime.Now));
            cmd.Parameters.AddWithValue("@futureLimit", ConvertToEastern(DateTime.Now.AddMinutes(15)));
            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                DateTime nextAppointmentTime = Convert.ToDateTime(result);
                MessageBox.Show($"Reminder: You have an appointment at {ConvertFromEastern(nextAppointmentTime).ToShortTimeString()} ({TimeZoneInfo.Local.StandardName}).", "Upcoming Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}