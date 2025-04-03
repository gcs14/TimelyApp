using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Service
{
    internal class UserService
    {
        public static List<User> Users;
        private static RegisterUser view = new RegisterUser();

        public static void AddUser (RegisterUser registerUserView, string username, string password, string confirmPassword)
        {
            view = registerUserView;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required.");
                ClearText(2);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                ClearText(1);
                return;
            }

            if (IsUsernameTaken(DBConnection.conn, username))
            {
                MessageBox.Show("Username is already in use.");
                ClearText(0);
                return;
            }

            int newUserId = GetNextUserId(DBConnection.conn);
            string query = "INSERT INTO user (userId, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@userId, @username, @password, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
            cmd.Parameters.AddWithValue("@userId", newUserId);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@active", 1);
            cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@lastUpdateBy", "");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registration successful.");
            CloseRegistrationForm(view);
        }

        private static bool IsUsernameTaken(MySqlConnection connection, string username)
        {
            string query = "SELECT COUNT(*) FROM user WHERE userName = @username";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private static int GetNextUserId(MySqlConnection connection)
        {
            string query = "SELECT MAX(userId) FROM user";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }

        private static void ClearText(int i)
        {
            switch (i)
            {
                case 0:
                    view.usernameText_Reg.Text = "";
                    view.usernameError.Visible = true;
                    break;
                case 1:
                    view.passwordText1_Reg.Text = "";
                    view.passwordText2_Reg.Text = "";
                    view.passwordError1.Visible = true;
                    view.passwordError2.Visible = true;
                    break;
                case 2:
                    view.usernameText_Reg.Text = "";
                    view.passwordText1_Reg.Text = "";
                    view.passwordText2_Reg.Text = "";
                    view.usernameError.Visible = true;
                    view.passwordError1.Visible = true;
                    view.passwordError2.Visible = true;
                    break;
            }
        }

        public static void CloseRegistrationForm(RegisterUser view)
        {
            view.Hide();
            new Login().ShowDialog();
            view.Close();
        }
    }
}
