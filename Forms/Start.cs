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
using System.Globalization;
using System.Diagnostics;

namespace DesktopSchedulingApp
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            showCorrectLang();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            
        }

        private void enterBtn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void loginBtn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }

        private void registerBtn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register().ShowDialog();
            this.Close();
        }

        private void showCorrectLang()
        {
            switch (RegionInfo.CurrentRegion.EnglishName)
            {
                case "United States":
                    MessageBox.Show("English");
                    break;
                case "Mexico":
                    MessageBox.Show("Spanish");
                    break;
            }

            
        }
    }
}
