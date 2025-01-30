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
        string language;
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Login(string language)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.language = language;

            if (language.Equals("spa"))
            {
                startBtn_Login.Text = "Comenzar";
                registerBtn_Login.Text = "Registrar";
                welcomeLabel_Login.Text = "¡Bienvenido de nuevo!";
                usernameLabel_Login.Text = "Nombre de usuario";
                passwordLabel_Login.Text = "Contraseña";
                loginSubmitBtn.Text = "Enviar";
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
            new Register().ShowDialog();
            this.Close();
        }

        private void loginSubmitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
