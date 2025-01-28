using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopSchedulingApp.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class Login : Form
    {
        Thread th;
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void previousBtn_Login(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            this.Hide();
            welcome.ShowDialog();
            this.Close();
        }
    }
}
