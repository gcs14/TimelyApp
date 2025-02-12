using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class Home : Form
    {
        string username;
        public Home(string currentUserName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            username = currentUserName;
        }

        private void CustomerBtn_Click(object sender, EventArgs e)
        {
            var viewCustomers = new ViewCustomers(username);
            viewCustomers.MdiParent = this;
            viewCustomers.Show();
        }
    }
}
