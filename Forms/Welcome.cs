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
        public Welcome()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void enterBtn_Start_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login().ShowDialog();
        }

        private void loginBtn_Start_Click(object sender, EventArgs e)
        {
            new Login().ShowDialog();
            this.Close();
        }

        private void registerBtn_Start_Click(object sender, EventArgs e)
        {
            new Register().ShowDialog();
            this.Close();
        }
    }
}
