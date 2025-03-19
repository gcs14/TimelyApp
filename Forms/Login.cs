using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class Login : Form
    {
        private Dictionary<string, Dictionary<string, string>> translations = new Dictionary<string, Dictionary<string, string>>();
        private string currentLanguage = "en";
        bool passwordHidden;
        private string loggedInUser;

        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            SetupTranslations();
            DetermineUserLocation();
            UpdateUILanguage();
        }

        private void SetupTranslations()
        {
            var englishTranslations = new Dictionary<string, string>
            {
                { "loginTitle", "LOGIN" },
                { "usernameLabel", "USERNAME" },
                { "passwordLabel", "PASSWORD" },
                { "enterButton", "Enter" },
                { "errorInvalidCredentials", "You've entered an invalid username or password." },
                { "errorEmptyFields", "Username and/or password can not be empty." },
                { "successLogin", "Login successful!" },
                { "appointmentAlert", "You have an appointment within 15 minutes!" },
                { "noAppointments", "No upcoming appointments." },
                { "errorDatabase", "Database connection error. Please try again later." }
            };
            translations.Add("en", englishTranslations);

            var spanishTranslations = new Dictionary<string, string>
            {
                { "loginTitle", "ACCEDAR" },
                { "usernameLabel", "NOMBRE DE USUARIO" },
                { "passwordLabel", "CONTRASEÑA" },
                { "enterButton", "ENVIAR" },
                { "errorInvalidCredentials", "Ha ingresado un nombre de usuario y contraseña no válidos." },
                { "errorEmptyFields", "El nombre de usuario y/o contraseña no pueden estar vacíos." },
                { "successLogin", "¡Inicio de sesión exitoso!" },
                { "appointmentAlert", "¡Tiene una cita en los próximos 15 minutos!" },
                { "noAppointments", "No hay citas próximas." },
                { "errorDatabase", "Error de conexión a la base de datos. Por favor, inténtelo más tarde." }
            };
            translations.Add("es", spanishTranslations);
        }

        private void DetermineUserLocation()
        {
            try
            {
                var currentCulture = CultureInfo.CurrentCulture;
                string userLanguage = currentCulture.TwoLetterISOLanguageName;

                if (userLanguage == "es")
                {
                    currentLanguage = "es";
                }
                else
                {
                    currentLanguage = "en";
                }

                // Get user's timezone for later use
                TimeZoneInfo localZone = TimeZoneInfo.Local;
                //lblTimeZone.Text = localZone.DisplayName;
            }
            catch (Exception ex)
            {
                currentLanguage = "en";
                Console.WriteLine($"Error determining user location: {ex.Message}");
            }
        }

        private void UpdateUILanguage()
        {
            loginLabel.Text = translations[currentLanguage]["loginTitle"];
            usernameLabel.Text = translations[currentLanguage]["usernameLabel"];
            passwordLabel.Text = translations[currentLanguage]["passwordLabel"];
            enterBtn.Text = translations[currentLanguage]["enterButton"];
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

        private bool VerifyLogin(string username, string password)
        {
            bool isValid = false;

            try
            {
                string query = "SELECT userId FROM user WHERE userName = @username AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                throw;
            }

            return isValid;
        }

        private void ClearText()
        {
            usernameText.Text = "";
            passwordText.Text = "";
            usernameError.Visible = true;
            passwordError.Visible = true;
        }

        //private void LogLogin(string username)
        //{
        //    try
        //    {
        //        string logFilePath = "Login_History.txt";
        //        string logEntry = $"{DateTime.Now} - User: {username} logged in\n";

        //        // Append to the log file
        //        File.AppendAllText(logFilePath, logEntry);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the error but don't disrupt the login process
        //        Console.WriteLine($"Error logging login: {ex.Message}");
        //    }
        //}

        private void CheckUpcomingAppointments(string username)
        {
            try
            {
                int userId = GetUserId(username);

                if (userId == -1)
                {
                    return; // User not found or error occurred
                }

                // Get current time
                DateTime now = DateTime.Now;

                // Define the 15-minute window
                DateTime fifteenMinutesFromNow = now.AddMinutes(15);

                // Check for appointments within the next 15 minutes

                string query = @"
                SELECT appointmentId, start, end, type, customer.customerName
                FROM appointment
                JOIN customer ON appointment.customerId = customer.customerId
                WHERE appointment.userId = @userId
                AND appointment.start BETWEEN @now AND @fifteenMin
                ORDER BY start";

                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@now", now);
                cmd.Parameters.AddWithValue("@fifteenMin", fifteenMinutesFromNow);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        // Build alert message for upcoming appointments
                        string alertMessage = translations[currentLanguage]["appointmentAlert"] + "\n\n";

                        while (reader.Read())
                        {
                            int appointmentId = Convert.ToInt32(reader["appointmentId"]);
                            DateTime start = Convert.ToDateTime(reader["start"]);
                            string type = reader["type"].ToString();
                            string customerName = reader["customerName"].ToString();

                            alertMessage += $"- {start.ToLocalTime():g}: {type} with {customerName}\n";
                        }

                        // Show alert for upcoming appointments
                        MessageBox.Show(alertMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error but don't disrupt the login process
                Console.WriteLine($"Error checking appointments: {ex.Message}");
            }
        }

        private int GetUserId(string username)
        {
            int userId = -1;

            try
            {
                string query = "SELECT userId FROM user WHERE userName = @username";
                MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn);
                cmd.Parameters.AddWithValue("@username", username);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user ID: {ex.Message}");
            }

            return userId;
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text.Trim();
            string password = passwordText.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(translations[currentLanguage]["errorEmptyFields"]);
                return;
            }

            try
            {
                // Verify credentials
                if (VerifyLogin(username, password))
                {
                    // Save username for later use
                    loggedInUser = username;

                    // Log the successful login
                    //LogLogin(username);

                    // Show success message
                    MessageBox.Show(translations[currentLanguage]["successLogin"]);

                    // Check for upcoming appointments
                    //CheckUpcomingAppointments(username);

                    // Open main form
                    this.Hide();
                    new Home(username).ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(translations[currentLanguage]["errorInvalidCredentials"]);
                    ClearText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(translations[currentLanguage]["errorDatabase"] + "\n" + ex.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterUser().ShowDialog();
            this.Close();
        }
    }
}
