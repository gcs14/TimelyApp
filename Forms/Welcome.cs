using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using DesktopSchedulingApp.Forms;

namespace DesktopSchedulingApp
{
    public partial class Welcome : Form
    {
        Thread th;
        public Welcome()
        {
            InitializeComponent();
        }

        private void welcomeEnterBtn_Click(object sender, EventArgs e)
        {
            //Login login = new Login();
            //this.Hide();
            //login.ShowDialog();

            this.Close();
            th = new Thread(OpenLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void welcomeLoginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void OpenLogin(Object obj)
        {
            Application.Run(new Login());
        }
    }
}
