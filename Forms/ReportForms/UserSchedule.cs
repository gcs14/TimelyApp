using DesktopSchedulingApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms.ReportForms
{
    public partial class UserSchedule : Form
    {
        int userId;

        public UserSchedule(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            userId = id;
            timeZoneLabel.Text += TimeZoneInfo.Local.StandardName;
            LoadReportData();
        }

        private void LoadReportData()
        {
            var reportData = ReportService.GetScheduleByUser(userId)
                .SelectMany(kvp => kvp.Value.Select(v => new { User = kvp.Key, v.Date, v.Time, v.Customer }))
                .OrderBy(a => a.Date)
                .ThenBy(a => a.Time)
                .ToList();
            scheduleDGV.DataSource = reportData;
            scheduleDGV.Columns["User"].Visible = false;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
