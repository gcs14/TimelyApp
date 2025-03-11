using DesktopSchedulingApp.Repository;
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

namespace DesktopSchedulingApp.Forms
{
    public partial class ViewAppointments : Form
    {
        string currentUser;
        public ViewAppointments(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            PopulateAppointmentTable();
            currentUser = username;
        }

        private void PopulateAppointmentTable()
        {
            DBCommands.LoadAppointmentData(this);
            dataGridView1.CurrentCell = null;
            dataGridView1.Columns["userId"].Visible = false;
            dataGridView1.Columns["customerId"].Visible = false;
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            new AddAppointment(currentUser).ShowDialog();
        }
    }
}
