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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DesktopSchedulingApp.Models;

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
        List<User> allUsers = new List<User>();

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
                isSpanish = true;
                TranslateToSpnaish_Register();
            }
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

        //private void ReadUserTable(string sql)
        //{
        //    MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    if (rdr.HasRows)
        //    {
        //        while (rdr.Read())
        //        {
        //            username = rdr["username"].ToString();
        //            password = rdr["password"].ToString();
        //            if (!userCredentials.ContainsKey(username))
        //            {
        //                userCredentials.Add(username, password);
        //            }
        //        }
        //        rdr.Close();
        //    }
        //}

        private void ReadUserTable(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    allUsers.Add(new User(
                        (int)cmd.LastInsertedId + 1, 
                        rdr["username"].ToString(),
                        rdr["password"].ToString(),
                        (byte)rdr["active"],
                        (DateTime)rdr["createTime"],
                        rdr["createdBy"].ToString(),
                        (DateTime)rdr["lastUpdate"],
                        rdr["lastUpdatedBy"].ToString()
                        ));
                }
                rdr.Close();
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Start().ShowDialog();
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login(ri).ShowDialog();
            this.Close();
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

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM User";
            ReadUserTable(sql);
            foreach (var user in allUsers)
            {
                MessageBox.Show($"{user.UserID}, {user.UserName}, {user.Password}");
            }
            //string sql = "SELECT Username, Password FROM User";
            //ReadUserTable(sql);
            //string x = "";

            //string cmdInsert = "INSERT INTO inf(name, surname) VALUES (@username, @password)";
            //MySqlCommand cmd = new MySqlCommand(cmdInsert, DBConnection.conn);
            //cmd.Parameters.AddWithValue("@id", cmd.LastInsertedId + 1);
            //cmd.Parameters.AddWithValue("@username", username_Register.Text);
            //cmd.Parameters.AddWithValue("@password", password_Register.Text);
            //cmd.Parameters.AddWithValue("@active", 1);
            //cmd.Parameters.AddWithValue("@active", 1);
            //cmd.ExecuteNonQuery();

            //if (!userCredentials.ContainsKey(username_Register.Text))
            //{
            //    ValidateInput();
            //}
            //MessageBox.Show("Username is already in use.");
        }
        
        private bool ValidateInput()
        {
            bool validated = false;
            switch (isSpanish)
            {
                case true:
                    if (!username_Register.Text.Equals("") && !password_Register.Text.Equals(""))
                    {
                        if (int.TryParse(username_Register.Text, out _))
                        {
                            MessageBox.Show("El nombre de usuario no puede ser un número.");
                        }
                        if (password_Register.Text.Length < 3)
                        {
                            MessageBox.Show("La contraseña debe tener más de tres caracteres.");
                        }
                        else
                        {
                            MessageBox.Show("Usuario registrado exitosamente.");
                            validated = true;
                        }
                        break;
                    }
                    MessageBox.Show("El nombre de usuario y/o contraseña no pueden estar vacíos.");
                    break;
                case false:
                    if (!username_Register.Text.Equals("") && !password_Register.Text.Equals(""))
                    {
                        if (int.TryParse(username_Register.Text, out _))
                        {
                            MessageBox.Show("Username can not be a number.");
                        }
                        if (password_Register.Text.Length < 3)
                        {
                            MessageBox.Show("Password must be longer than three characters.");
                        }
                        else
                        {
                            MessageBox.Show("User successfully registered.");
                        }
                        break;
                    }
                    MessageBox.Show("Username and/or password can not be empty.");
                    validated = true;
                    break;
            }
            return validated;
        }
    }
}
