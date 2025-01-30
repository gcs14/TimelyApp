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
        RegionInfo currentRegion = RegionInfo.CurrentRegion;
        public Start()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FindRegion();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            
        }

        private void enterBtn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(currentRegion).ShowDialog();
            this.Close();
        }

        private void loginBtn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(currentRegion).ShowDialog();
            this.Close();
        }

        private void registerBtn_Start_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register(currentRegion).ShowDialog();
            this.Close();
        }

        private void FindRegion()
        {
            string regionName = RegionInfo.CurrentRegion.EnglishName;
            if (Language.SpanishSpeaking.Contains(regionName))
            {
                TranslateToSpanish();
            }
        }

        private void TranslateToSpanish()
        {
            registerBtn_Start.Text = "Registrar";
            loginBtn_Start.Text = "Acceder";
            loginBtn_Start.Location = new Point(853, 10);
            myScheduleLabel.Text = "MiAgenda";
            myScheduleLabel.Location = new Point(673, 200);
            enterBtn.Text = "Entrar";
        }
    }
}
