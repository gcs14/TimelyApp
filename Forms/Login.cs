using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        RegionInfo ri;
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Login(RegionInfo ri)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ri = ri;

            if (Language.SpanishSpeaking.Contains(ri.EnglishName))
            {
                TranslateToSpanish_Login();
            }
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
            new Register(ri).ShowDialog();
            this.Close();
        }

        private void loginSubmitBtn_Click(object sender, EventArgs e)
        {

        }

        private void TranslateToSpanish_Login()
        {
            startBtn_Login.Text = "< Comenzar";
            registerBtn_Login.Text = "Registrar";
            welcomeLabel_Login.Text = "¡Bienvenido \nDe Nuevo!";
            welcomeLabel_Login.Font = new Font("Cambria", 30, FontStyle.Bold);
            welcomeLabel_Login.Location = new Point(656, 70);
            usernameLabel_Login.Text = "Nombre de usuario";
            passwordLabel_Login.Text = "Contraseña";
            loginSubmitBtn.Text = "Enviar";
        }
    }
}
