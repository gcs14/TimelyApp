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

            CustomerService.LoadCustomerData(this);
            durationComboBox.SelectedIndex = 0;
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
            AppointmentExceptions appointmentExceptions = new();
            if (appointmentExceptions.AddAppointmentExceptions(this))
            {
                AppointmentService.AddAppointment(this, username);
            }
        }

        private void AddCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
