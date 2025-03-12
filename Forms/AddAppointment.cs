using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class AddAppointment : Form
    {
        AppointmentExceptions appointmentExceptions = new();
        string currentUser;
        public AddAppointment(string username)
        {
            currentUser = username;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            DBCommands.LoadCustomerData(this);
            durationComboBox.SelectedIndex = 0;
        }

        private void NewCustomer_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
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

        private void addAppointmentBtn_Click(object sender, EventArgs e)
        {
            Customer selectedCustomer = CustomerService.FindByCustomerName(Convert.ToString(custNamesDGV.CurrentRow.Cells[1].Value.ToString()));
            
            DateTime appointmentStart = AppointmentService.MergeDateTime(
                monthCalendar.SelectionStart.ToShortDateString(),
                AppointmentService.GetSelectedTime(hoursDGV.CurrentRow.Cells[0].Value.ToString())
                );
            DateTime appointmentEnd = appointmentStart.AddMinutes(Convert.ToDouble(durationComboBox.Text.Substring(0,2)));

            Appointment appointment = new (
                AppointmentService.GetAppointmentID(selectedCustomer.CustomerId, 1, appointmentStart, appointmentEnd),
                selectedCustomer.CustomerId,
                UserService.GetUserId(currentUser),
                typeComboBox.Text,
                appointmentStart,
                appointmentEnd
                );

            if (appointmentExceptions.AddAppointmentExceptions(this))
            {
                AppointmentService.Appointments.Add(appointment);
                DBCommands.InsertAppointmentData(appointment);
                this.Close();
            }
        }
    }
}
