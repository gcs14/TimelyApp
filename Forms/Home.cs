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
    public partial class Home : Form
    {
        string username;
        public Home(string currentUserName)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            username = currentUserName;
            CustomerService.LoadCustomers();
        }

        private void CustomerBtn_Click(object sender, EventArgs e)
        {
            var viewCustomers = new ViewCustomers(username);
            viewCustomers.MdiParent = this;
            viewCustomers.Show();
        }
    }
}
