using DesktopSchedulingApp.Models;
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

namespace DesktopSchedulingApp.Forms
{
    public partial class AddAppointment : Form
    {
        string currentUser;
        public AddAppointment(string username)
        {
            currentUser = username;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //AppointmentService.SetAvailableHours();

            DBCommands.LoadCustomerData(this);
            durationComboBox.SelectedIndex = 0;

            //hoursDGV.Columns.Add("Time", "Time");
            //hoursDGV.CurrentCell = null;
            //foreach (KeyValuePair<TimeOnly, string> entry in AppointmentService.BusinessHours)
            //{
            //    hoursDGV.Rows.Add(entry.Value);
            //}

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
            
            string date = monthCalendar.SelectionStart.ToShortDateString();
            string time = AppointmentService.GetSelectedTime(hoursDGV.CurrentRow.Cells[0].Value.ToString());
            DateTime appointmentStart = Convert.ToDateTime(date + " " + time);
            DateTime appointmentEnd = appointmentStart.AddMinutes(Convert.ToDouble(durationComboBox.Text));

            Appointment appointment = new(
                AppointmentService.GetAppointmentID(selectedCustomer.CustomerId, 1, appointmentStart, appointmentEnd),
                selectedCustomer.CustomerId,
                1,
                typeComboBox.Text,
                appointmentStart,
                appointmentEnd
                );
        }
    }
}
