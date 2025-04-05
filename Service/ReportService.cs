using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DesktopSchedulingApp.Service
{
    internal class ReportService
    {
        public static Dictionary<string, int> GetAppointmentTypesByMonth(int userId, int year)
        {
            //var report = new Dictionary<string, int>();
            var report = Enumerable.Range(1, 12)
                .ToDictionary(m => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m), m => 0);

            string query = "SELECT MONTH(start) AS Month, COUNT(*) AS Count FROM appointment WHERE userId = @userId AND YEAR(start) = @year GROUP BY Month ORDER BY Month";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@year", year);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(reader.GetInt32("Month"));
                    report[monthName] = reader.GetInt32("Count");
                }
            }
            return report;
        }

        // this method is problematic and does not work well with UTC
        public static Dictionary<string, List<(DateTime Date, string Time, string Customer)>> GetScheduleByUser(int userId)
        {
            var report = new Dictionary<string, List<(DateTime, string, string)>>();

            string query = "SELECT u.userName, a.start, c.customerName FROM appointment a " +
                       "JOIN user u ON a.userId = u.userId " +
                       "JOIN customer c ON a.customerId = c.customerId " +
                       "WHERE a.start >= @nowEST AND a.userId = @userId " +
                       "ORDER BY a.start";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@nowEST", AppointmentService.ConvertToEastern(DateTime.Now));
            cmd.Parameters.AddWithValue("@userId", userId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string user = reader.GetString("userName");
                    DateTime easternStart = reader.GetDateTime("start");
                    DateTime localStart = AppointmentService.ConvertFromEastern(easternStart);
                    //TimeSpan time = localStart.TimeOfDay;
                    string time = localStart.ToShortTimeString();
                    string customer = reader.GetString("customerName");

                    if (!report.ContainsKey(user))
                    {
                        report[user] = new List<(DateTime, string, string)>();
                    }
                    report[user].Add((localStart.Date, time, customer));
                }
            }
            return report;
        }
    }
}
