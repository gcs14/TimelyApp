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
        public AddAppointment()
        {
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
            AppointmentService.GetSelectedDate(monthCalendar1.SelectionRange.Start.ToShortDateString());
            AppointmentService.SetAvailableHours(this);
        }
    }
}
