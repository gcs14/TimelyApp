using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopSchedulingApp.Service
{
    internal class AppointmentService
    {
        public static List<Appointment> Appointments;
        private static int highestID = 0;

        public static Dictionary<TimeOnly, string> BusinessHours = new();
        public static Dictionary<DateOnly, Dictionary<TimeOnly, TimeSpan>> AppointmentDates = new();
        public static DateOnly selectedDate;

        internal static void ReadAppointmentData(string sql)
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

                // for each day in the database I want to track when there is an appointment and for how long
                // ex: [2/27/2025, [(9:00AM, 30min), (12:30pm, 60min), (1:30pm, 60min), (4:00pm, 30min)]]
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

        public static void SetAvailableHours(AddAppointment view)
        {
            BusinessHours.Clear();
            BusinessHours.Add(new TimeOnly(09, 00, 00), "9:00 AM");
            BusinessHours.Add(new TimeOnly(09, 30, 00), "9:30 AM");
            BusinessHours.Add(new TimeOnly(10, 00, 00), "10:00 AM");
            BusinessHours.Add(new TimeOnly(10, 30, 00), "10:30 AM");
            BusinessHours.Add(new TimeOnly(11, 00, 00), "11:00 AM");
            BusinessHours.Add(new TimeOnly(11, 30, 00), "11:30 AM");
            BusinessHours.Add(new TimeOnly(12, 00, 00), "12:00 PM");
            BusinessHours.Add(new TimeOnly(12, 30, 00), "12:30 PM");
            BusinessHours.Add(new TimeOnly(13, 00, 00), "1:00 PM");
            BusinessHours.Add(new TimeOnly(13, 30, 00), "1:30 PM");
            BusinessHours.Add(new TimeOnly(14, 00, 00), "2:00 PM");
            BusinessHours.Add(new TimeOnly(14, 30, 00), "2:30 PM");
            BusinessHours.Add(new TimeOnly(15, 00, 00), "3.00 PM");
            BusinessHours.Add(new TimeOnly(15, 30, 00), "3:30 PM");
            BusinessHours.Add(new TimeOnly(16, 00, 00), "4:00 PM");
            BusinessHours.Add(new TimeOnly(16, 30, 00), "4:30 PM");

            if (selectedDate < DateOnly.FromDateTime(DateTime.Now)
                || selectedDate.DayOfWeek == DayOfWeek.Saturday 
                || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                BusinessHours.Clear();
            }

            foreach (KeyValuePair<TimeOnly, string> hour in BusinessHours)
            {
                if (selectedDate == DateOnly.FromDateTime(DateTime.Today)
                    && hour.Key < TimeOnly.FromDateTime(DateTime.Now))
                {
                    BusinessHours.Remove(hour.Key);
                }
            }

            if (AppointmentDates.ContainsKey(selectedDate))
            {
                foreach (KeyValuePair<TimeOnly, TimeSpan> time in AppointmentDates[selectedDate])
                {
                    foreach (TimeOnly t in BusinessHours.Keys)
                    {
                        if (time.Key == t)
                        {
                            if (time.Value.TotalMinutes == 30.00)
                            {
                                BusinessHours.Remove(BusinessHours.Keys.ToList()[GetBusinessHoursKeyIndex(t) + 1]);
                            }
                            if (time.Value.TotalMinutes == 60.00)
                            {
                                BusinessHours.Remove(BusinessHours.Keys.ToList()[GetBusinessHoursKeyIndex(t) + 1]);
                                if (time.Key != TimeOnly.Parse("16:00:00"))
                                {
                                    BusinessHours.Remove(BusinessHours.Keys.ToList()[GetBusinessHoursKeyIndex(t) + 2]);
                                }
                            }
                            BusinessHours.Remove(t);
                        }
                    }
                }
            }

            view.hoursDGV.Columns.Add("Time", "Time");
            view.hoursDGV.CurrentCell = null;
            foreach (KeyValuePair<TimeOnly, string> entry in AppointmentService.BusinessHours)
            {
                view.hoursDGV.Rows.Add(entry.Value);
            }
        }

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

        public static int GetAppointmentID(int customerId, int userId, DateTime start, DateTime end)
        {
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.CustomerId == customerId
                    && appointment.UserId == userId
                    && appointment.StartTime == start
                    && appointment.EndTime == end)
                {
                    return appointment.AppointmentId;
                }
            }
            return highestID += 1;
        }
    }
}
