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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void startBtn_Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Start().ShowDialog();
            this.Close();
        }

        private void loginBtn_Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void registerSubmitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
