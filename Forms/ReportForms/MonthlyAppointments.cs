using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace DesktopSchedulingApp.Forms.ReportForms
{
    public partial class MonthlyAppointments : Form
    {
        private int userId;

        public MonthlyAppointments(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Appointments by Month";
            userId = id;

            LoadYearsFromDatabase();
            LoadReportData();
        }

        private void LoadYearsFromDatabase()
        {
            string query = "SELECT DISTINCT YEAR(start) AS Year FROM appointment WHERE userId = @userId ORDER BY Year DESC";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yearComboBox.Items.Add(reader.GetInt32("Year"));
                }
            }
            yearComboBox.SelectedItem = DateTime.Now.Year;
        }

        private void LoadReportData()
        {
            if (yearComboBox.SelectedItem == null)
            {
                return;
            }
            int selectedYear = (int)yearComboBox.SelectedItem;
            label2.Focus();
            var reportData = ReportService.GetAppointmentTypesByMonth(userId, selectedYear);
            monthReportDGV.DataSource = reportData.Select(kvp => new { Month = kvp.Key, Appointments = kvp.Value }).ToList();
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
