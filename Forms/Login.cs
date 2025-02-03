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
using DesktopSchedulingApp.Repository;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace DesktopSchedulingApp.Forms
{
    public partial class Login : Form
    {
        RegionInfo ri;
        string username;
        string password;
        bool passwordHidden;
        bool isSpanish = false;
        int loginCount = 0;

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
                isSpanish = true;
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
            if (loginCount <= 1)
            {
                LoginValidation();
            }
            else
            {
                if (isSpanish)
                {
                    MessageBox.Show("Un usuario ya ha iniciado sesión.");
                }
                MessageBox.Show("A user is already logged in.");
            }
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

        private void passwordHide_Login_Click(object sender, EventArgs e)
        {
            if (passwordHidden)
            {
                pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.hidden;
                password_Login.PasswordChar = '*';
            }
            else
            {
                pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.show;
                password_Login.PasswordChar = '\0';
            }
            passwordHidden = !passwordHidden;
        }

        private bool InputEvaluation(string username, string password)
        {
            bool validated = false;
            if (!username_Login.Text.Equals("") && !password_Login.Text.Equals(""))
            {
                if (username_Login.Text.Equals(username) && password_Login.Text.Equals(password))
                {
                    if (isSpanish)
                    {
                        MessageBox.Show("Inicio de sesión exitoso.");
                    }
                    else
                    {
                        MessageBox.Show("Login successful.");
                    }
                    validated = true;
                }
                else
                {
                    if (isSpanish)
                    {
                        MessageBox.Show("Ha ingresado un nombre de usuario y contraseña no válidos.");
                    }
                    else
                    {
                        MessageBox.Show("You've entered an invalid username or password.");
                    }
                }
            }
            else
            {
                if (isSpanish)
                {
                    MessageBox.Show("El nombre de usuario y/o contraseña no pueden estar vacíos.");
                }
                MessageBox.Show("Username and/or password can not be empty.");
            }
            return validated;
        }

        private void LoginValidation()
        {
            string sql = "SELECT Username, Password FROM User WHERE Username =@Username AND Password =@Password";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            cmd.Parameters.AddWithValue("@Username", username_Login.Text);
            cmd.Parameters.AddWithValue("@Password", password_Login.Text);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //MessageBox.Show(rdr["Username"] + "---" + rdr["Password"]);
                username = rdr["username"].ToString();
                password = rdr["password"].ToString();
            }
            rdr.Close();
            if (InputEvaluation(username, password))
            {
                //loginCount++;
                this.Hide();
                new Dashboard().ShowDialog();
                this.Close();
            }
            
        }
    }
}
