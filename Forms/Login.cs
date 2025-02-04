using MySql.Data.MySqlClient;
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
using DesktopSchedulingApp.Repository;

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

        private void EnterBtn_Click(object sender, EventArgs e)
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
            // need to use CultureInfo.CurrentCulture.TwoLetterISOLanguageName
            loginLabel.Text = "ACCEDAR";
            usernameLabel.Text = "NOMBRE DE USUARIO";
            passwordLabel.Text = "CONTRASEÑA";
            enterBtn.Text = "ENVIAR";
        }

        private void passwordHide_Click(object sender, EventArgs e)
        {
            if (passwordHidden)
            {
                pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.hidden;
                passwordText.PasswordChar = '*';
            }
            else
            {
                pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.show;
                passwordText.PasswordChar = '\0';
            }
            passwordHidden = !passwordHidden;
        }

        private bool InputEvaluation(string username, string password)
        {
            bool validated = false;
            if (!usernameText.Text.Equals("") && !passwordText.Text.Equals(""))
            {
                if (usernameText.Text.Equals(username) && passwordText.Text.Equals(password))
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
            cmd.Parameters.AddWithValue("@Username", usernameText.Text);
            cmd.Parameters.AddWithValue("@Password", passwordText.Text);
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
                new Home().ShowDialog();
                this.Close();
            }
        }
    }
}
