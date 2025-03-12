using DesktopSchedulingApp.Repository;
using System;
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
            DBCommands.LoadUserData();
            dataGridView1.CurrentCell = null;
            dataGridView1.Columns["userId"].Visible = false;
            dataGridView1.Columns["customerId"].Visible = false;
            dataGridView1.Columns["End Date"].Visible = false;
            dataGridView1.Columns[6].DefaultCellStyle.Format = @"MM\/dd\/yyyy";
            dataGridView1.Columns[7].DefaultCellStyle.Format = @"MM\/dd\/yyyy";
            dataGridView1.Columns[8].DefaultCellStyle.Format = @"hh\:mm";
            dataGridView1.Columns[9].DefaultCellStyle.Format = @"hh\:mm";
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            new AddAppointment(currentUser).ShowDialog();
            PopulateAppointmentTable();
        }
    }
}
