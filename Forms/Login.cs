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
            string sql = "SELECT Username, Password FROM User";
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    username = rdr["username"].ToString();
                    password = rdr["password"].ToString();
                    //MessageBox.Show($"Username: {username}, Password: {password}");
                }
                rdr.Close();
                if (username_Login.Text.Equals(username) && password_Login.Text.Equals(password))
                {
                    MessageBox.Show("Your username and password worked. You made it in bruv!");
                }
                else
                {
                    MessageBox.Show("You Wasteman! Thats not it!");
                }
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
    }
}
