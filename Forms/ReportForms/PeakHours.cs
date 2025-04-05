using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms.ReportForms
{
    public partial class PeakHours : Form
    {
        int userId;

        public PeakHours(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            userId = id;
            LoadPeakHoursData();
        }

        private void LoadPeakHoursData()
        {
            firstLabel.Text = $"Most Booked: ---";
            secondLabel.Text = $"Second Most: ---";
            thirdLabel.Text = $"Third Most: ---";
            var peakHours = GetTopBookedTimeSlots();

            if (peakHours.Count > 0) firstLabel.Text = $"Most Booked: {peakHours[0].Time} (EST) - {peakHours[0].Percentage}%";
            if (peakHours.Count > 1) secondLabel.Text = $"Second Most: {peakHours[1].Time} (EST) - {peakHours[1].Percentage}%";
            if (peakHours.Count > 2) thirdLabel.Text = $"Third Most: {peakHours[2].Time} (EST) - {peakHours[2].Percentage}%";
        }

        private List<(string Time, double Percentage)> GetTopBookedTimeSlots()
        {
            Dictionary<string, int> timeSlotCounts = new Dictionary<string, int>();
            int totalAppointments = 0;
            
            string query = "SELECT appointment.start FROM appointment WHERE appointment.userId = @userId";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    TimeOnly t = TimeOnly.FromDateTime(reader.GetDateTime("start"));
                    string timeSlot = t.ToString("hh:mm tt");
                    if (timeSlotCounts.ContainsKey(timeSlot))
                        timeSlotCounts[timeSlot]++;
                    else
                        timeSlotCounts[timeSlot] = 1;

                    totalAppointments++;
                }
            }

            return timeSlotCounts
                .OrderByDescending(kvp => kvp.Value)
                .Take(3)
                .Select(kvp => (kvp.Key, Math.Round((kvp.Value / (double)totalAppointments) * 100, 2)))
                .ToList();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
