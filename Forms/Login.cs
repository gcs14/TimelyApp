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
using Microsoft.Win32;

namespace DesktopSchedulingApp.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void startBtn_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Start().ShowDialog();
            this.Close();
        }

        private void registerBtn_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register().ShowDialog();
            this.Close();
        }

        private void loginSubmitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
