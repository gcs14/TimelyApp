using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class Register : Form
    {
        RegionInfo ri;
        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Register(RegionInfo ri)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ri = ri;

            if (Language.SpanishSpeaking.Contains(ri.EnglishName))
            {
                TranslateToSpnaish_Register();
            }
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
            new Login(ri).ShowDialog();
            this.Close();
        }

        private void registerSubmitBtn_Click(object sender, EventArgs e)
        {

        }

        private void TranslateToSpnaish_Register()
        {
            startBtn_Register.Text = "< Comenzar";
            loginBtn_Register.Text = "Acceder";
            loginBtn_Register.Location = new Point(853, 10);
            createAccountLabel.Text = "Crear Cuenta";
            createAccountLabel.Font = new Font("Cambria", 32, FontStyle.Bold);
            usernameLabel_Register.Text = "Nombre de usuario";
            passwordLabel_Register.Text = "Contraseña";
            RegisterSubmitBtn.Text = "Enviar";
        }
    }
}
