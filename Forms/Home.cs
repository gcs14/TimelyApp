using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class Home : Form
    {
        readonly string username;
        public Home(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.username = username;
        }

        private void CustomerBtn_Click(object sender, EventArgs e)
        {
            var viewCustomers = new ViewCustomers();
            viewCustomers.MdiParent = this;
            viewCustomers.Show();
        }

        private void AppointmentBtn_Click(object sender, EventArgs e)
        {
            var viewAppointments = new ViewAppointments(username);
            viewAppointments.MdiParent = this;
            viewAppointments.Show();
        }
    }
}
