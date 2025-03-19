using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = usernameText_Reg.Text.Trim();
            string password = passwordText1_Reg.Text.Trim();
            string confirmPassword = passwordText2_Reg.Text.Trim();

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
            CloseRegistrationForm();
        }

        private bool IsUsernameTaken(MySqlConnection connection, string username)
        {
            string query = "SELECT COUNT(*) FROM user WHERE userName = @username";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        private int GetNextUserId(MySqlConnection connection)
        {
            string query = "SELECT MAX(userId) FROM user";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            object result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }

        private void ClearText(int i)
        {
            switch (i)
            {
                case 0:
                    usernameText_Reg.Text = "";
                    usernameError.Visible = true;
                    break;
                case 1:
                    passwordText1_Reg.Text = "";
                    passwordText2_Reg.Text = "";
                    passwordError1.Visible = true;
                    passwordError2.Visible = true;
                    break;
                case 2:
                    usernameText_Reg.Text = "";
                    passwordText1_Reg.Text = "";
                    passwordText2_Reg.Text = "";
                    usernameError.Visible = true;
                    passwordError1.Visible = true;
                    passwordError2.Visible = true;
                    break;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            CloseRegistrationForm();
        }

        private void CloseRegistrationForm()
        {
            this.Hide();
            new Login().ShowDialog();
            this.Close();
        }
    }
}
