using DesktopSchedulingApp.Forms.ReportForms;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class Home : Form
    {
        private int userId;
        readonly string username;
        public Home(string username, int userId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.username = username;
            this.Text = "Appointment Calendar";
            this.userId = userId;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            AppointmentService.CheckUpcomingAppointments(userId);
            welcomeLabel.Text += $"\n{username}!";
        }

        private void CustomerBtn_Click(object sender, EventArgs e)
        {
            var viewCustomers = new ViewCustomers();
            //viewCustomers.MdiParent = this;
            viewCustomers.Show();
        }

        private void AppointmentBtn_Click(object sender, EventArgs e)
        {
            var viewAppointments = new ViewAppointments(username);
            //viewAppointments.MdiParent = this;
            viewAppointments.Show();
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            new ViewCalendar(userId).ShowDialog();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                this.Hide();
                new Login().ShowDialog();
                this.Close();
            }
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to quit?", "Confirm Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void monthlyAppointmentsBtn_Click(object sender, EventArgs e)
        {
            new MonthlyAppointments(userId).ShowDialog();
        }
    }
}
