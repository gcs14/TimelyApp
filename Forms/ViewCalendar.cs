using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ViewCalendar : Form
    {
        readonly int userId;

        public ViewCalendar(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            userId = id;
            this.Text = "Appointment Calendar";
            monthCalendar1.DateSelected += MonthCalendar_DateSelected;
            LoadAppointmentsForMonth();
        }

        private void LoadAppointmentsForMonth()
        {
            string query = "SELECT DISTINCT DATE(start) AS appointmentDate FROM appointment WHERE userId = @userId";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    monthCalendar1.AddBoldedDate(Convert.ToDateTime(reader["appointmentDate"]));
                }
            }
            monthCalendar1.UpdateBoldedDates();
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            LoadAppointmentsForDay(e.Start);
        }

        private void LoadAppointmentsForDay(DateTime date)
        {
            flowLayoutPanel1.Controls.Clear();

            string query = @"SELECT c.customerName, a.start, a.end 
                                FROM appointment a 
                                JOIN customer c ON a.customerId = c.customerId 
                                WHERE a.userId = @userId AND DATE(a.start) = @date 
                                ORDER BY a.start";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@date", date);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime start = AppointmentService.ConvertFromEastern(Convert.ToDateTime(reader["start"]));
                    DateTime end = AppointmentService.ConvertFromEastern(Convert.ToDateTime(reader["end"]));

                    string appointmentInfo = $"{reader["customerName"]}: {start.ToShortTimeString()} - {end.ToShortTimeString()} {TimeZoneInfo.Local.StandardName}";
                    Label appointmentLabel = new Label { Text = appointmentInfo, AutoSize = true, Padding = new Padding(5), BorderStyle = BorderStyle.FixedSingle };
                    flowLayoutPanel1.Controls.Add(appointmentLabel);
                }
            }
        }
    }
}
