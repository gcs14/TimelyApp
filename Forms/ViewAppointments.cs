using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ViewAppointments : Form
    {
        int selectedAppointmentId;
        string username;

        public ViewAppointments(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            PopulateAppointmentTable();
            this.username = username;
        }

        private void PopulateAppointmentTable()
        {
            AppointmentService.LoadAppointmentData(this);
            UserService.LoadUserData();
            dataGridView1.CurrentCell = null;
            dataGridView1.Columns["userId"].Visible = false;
            dataGridView1.Columns["customerId"].Visible = false;
            dataGridView1.Columns["End Date"].Visible = false;
            dataGridView1.Columns[6].DefaultCellStyle.Format = @"MM\/dd\/yyyy";
            dataGridView1.Columns[7].DefaultCellStyle.Format = @"MM\/dd\/yyyy";
            dataGridView1.Columns[8].DefaultCellStyle.Format = @"hh\:mm";
            dataGridView1.Columns[9].DefaultCellStyle.Format = @"hh\:mm";
        }

        private void AddAppointmentBtn_Click(object sender, EventArgs e)
        {
            new AddAppointment(username).ShowDialog();
            PopulateAppointmentTable();
        }

        private void ModifyAppointmentBtn_Click(object sender, EventArgs e)
        {
            new ModifyAppointment(selectedAppointmentId).ShowDialog();
            PopulateAppointmentTable();
        }

        private void DeleteAppointmentBtn_Click(object sender, EventArgs e)
        {
            AppointmentService.DeleteAppointment(selectedAppointmentId);
            PopulateAppointmentTable();
        }

        private void AppointmentSelection(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedAppointmentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
