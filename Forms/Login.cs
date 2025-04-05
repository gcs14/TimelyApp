using DesktopSchedulingApp.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

                TimeZoneInfo localZone = TimeZoneInfo.Local;
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

        private void LogLogin(string username)
        {
            try
            {
                //string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.ToString();
                string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString();
                string logsFolder = Path.Combine(solutionDirectory, "Logs");

                if (!Directory.Exists(logsFolder))
                {
                    Directory.CreateDirectory(logsFolder);
                }

                string logEntry = $"{DateTime.Now} - User: \"{username}\" logged in";

                string filePath = Path.Combine(logsFolder, "Login_History.txt");
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving log file: {ex.Message}");
            }
        }

        public static void LogLogout(string username)
        {
            try
            {
                //string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.ToString();
                string solutionDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).ToString();
                string logsFolder = Path.Combine(solutionDirectory, "Logs");

                if (!Directory.Exists(logsFolder))
                {
                    Directory.CreateDirectory(logsFolder);
                }

                string logEntry = $"{DateTime.Now} - User: \"{username}\" logged out";

                string filePath = Path.Combine(logsFolder, "Login_History.txt");
                File.AppendAllText(filePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving log file: {ex.Message}");
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
                if (VerifyLogin(username, password))
                {
                    loggedInUser = username;
                    LogLogin(username);
                    MessageBox.Show(translations[currentLanguage]["successLogin"]);

                    this.Hide();
                    new Home(username, GetUserId(username)).ShowDialog();
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
