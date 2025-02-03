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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;

namespace DesktopSchedulingApp.Forms
{
    public partial class Register : Form
    {
        RegionInfo ri;
        string username;
        string password;
        bool passwordHidden;
        bool isSpanish = false;
        Dictionary<string, string> userCredentials = new Dictionary<string, string>();

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
            string sql = "SELECT Username, Password FROM User";
            ReadUserTable(sql);
            //MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            //MySqlDataReader rdr = cmd.ExecuteReader();

            //if (rdr.HasRows)
            //{
            //    while (rdr.Read())
            //    {
            //        username = rdr["username"].ToString();
            //        password = rdr["password"].ToString();
            //        userCredentials.Add(username, password);
            //    }
            //    rdr.Close();
            //}
                string x = "";
                foreach (var user in userCredentials)
                {
                    x += user.Value + ", " + user.Key + "\n";
                }
                MessageBox.Show(x);

                try
                {
                    userCredentials.ContainsKey(username_Register.Text);
                    MessageBox.Show("Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Username is already in use.");
                }
            //}
        }

        private void ReadUserTable(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    username = rdr["username"].ToString();
                    password = rdr["password"].ToString();
                    if (!userCredentials.ContainsKey(username))
                    {
                        userCredentials.Add(username, password);
                    }
                }
                rdr.Close();
            }
        }

        private void passwordHide_Register_Click(object sender, EventArgs e)
        {
            if (passwordHidden)
            {
                pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.hidden;
                password_Register.PasswordChar = '*';
            }
            else
            {
                pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.show;
                password_Register.PasswordChar = '\0';
            }
            passwordHidden = !passwordHidden;
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

        private bool RegisterInputEvaluation(string username, string password)
        {
            bool validated = false;
            if (!username_Register.Text.Equals("") && !password_Register.Text.Equals(""))
            {
                if (isSpanish)
                {
                    MessageBox.Show("User successfully registered.");
                }
                else
                {
                    MessageBox.Show("Usuario registrado exitosamente.");
                }
                validated = true;
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
    }
}
