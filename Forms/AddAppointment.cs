using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class AddAppointment : Form
    {
        string username;

        public AddAppointment(string username)
        {
            this.username = username;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            typeComboBox.SelectedIndex = 0;
            durationComboBox.SelectedIndex = 0;
            CustomerService.LoadCustomerData(this);
            TimeZoneLabel.Text = TimeZoneInfo.Local.StandardName;
        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            CustomerService.LoadCustomerData(this);
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (hoursDGV.Columns.Contains("Time"))
            {
                hoursDGV.Columns.Remove("Time");
            }
            AppointmentService.GetSelectedDate(monthCalendar.SelectionRange.Start.ToShortDateString());
            AppointmentService.SetAvailableHours(this);
        }

        private void AddAppointmentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentExceptions appointmentExceptions = new();
                if (appointmentExceptions.AddAppointmentExceptions(this))
                {
                    AppointmentService.AddAppointment(this, username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
