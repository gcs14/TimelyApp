using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
