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
using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Service;
using System.Drawing.Drawing2D;

namespace DesktopSchedulingApp.Forms
{
    public partial class Login : Form
    {
        //RegionInfo ri;
        //static string username;
        //string password;
        //bool passwordHidden;
        //bool isSpanish = false;
        //int loginCount;
        //User CurrentUser;

        //public Login()
        //{
        //    InitializeComponent();
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Equals("es"))
        //    {
        //        isSpanish = true;
        //        TranslateToSpanish_Login();
        //    }
        //}

        //private void TranslateToSpanish_Login()
        //{
        //    loginLabel.Text = "ACCEDAR";
        //    usernameLabel.Text = "NOMBRE DE USUARIO";
        //    passwordLabel.Text = "CONTRASEÑA";
        //    enterBtn.Text = "ENVIAR";
        //}

        //private void passwordHide_Click(object sender, EventArgs e)
        //{
            //if (passwordHidden)
            //{
            //    pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.hidden;
            //    passwordText.PasswordChar = '*';
            //}
            //else
            //{
            //    pictureBox1.Image = DesktopSchedulingApp.Properties.Resources.show;
            //    passwordText.PasswordChar = '\0';
            //}
            //passwordHidden = !passwordHidden;
        //}

        //private bool InputEvaluation(string username, string password)
        //{
        //    bool validated = false;
        //    if (!usernameText.Text.Equals("") && !passwordText.Text.Equals(""))
        //    {
        //        if (usernameText.Text.Equals(username) && passwordText.Text.Equals(password))
        //        {
        //            if (isSpanish)
        //            {
        //                MessageBox.Show("Inicio de sesión exitoso.");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Login successful.");
        //            }
        //            validated = true;
        //        }
        //        else
        //        {
        //            if (isSpanish)
        //            {
        //                MessageBox.Show("Ha ingresado un nombre de usuario y contraseña no válidos.");
        //            }
        //            else
        //            {
        //                MessageBox.Show("You've entered an invalid username or password.");
        //            }
        //            ClearText(2);
        //        }
        //    }
        //    else
        //    {
        //        if (isSpanish)
        //        {
        //            MessageBox.Show("El nombre de usuario y/o contraseña no pueden estar vacíos.");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Username and/or password can not be empty.");
        //        }
        //        ClearText(2);
        //    }
        //    return validated;
        //}

        //private void LoginValidation()
        //{
        //    string sql = "SELECT Username, Password FROM User WHERE Username =@Username AND Password =@Password";
        //    MySqlCommand cmd = new MySqlCommand(sql, DBConnection.conn);
        //    cmd.Parameters.AddWithValue("@Username", usernameText.Text);
        //    cmd.Parameters.AddWithValue("@Password", passwordText.Text);
        //    MySqlDataReader rdr = cmd.ExecuteReader();

        //    while (rdr.Read())
        //    {
        //        username = rdr["username"].ToString();
        //        password = rdr["password"].ToString();
        //    }
        //    rdr.Close();
        //    if (InputEvaluation(username, password))
        //    {
        //        this.Hide();
        //        new Home(username).ShowDialog();
        //        this.Close();
        //    }
        //}

        //private void EnterBtn_Click(object sender, EventArgs e)
        //{
            //if (loginCount <= 1)
            //{
            //    LoginValidation();

            //}
            //else
            //{
            //    if (isSpanish)
            //    {
            //        MessageBox.Show("Un usuario ya ha iniciado sesión.");
            //    }
            //    MessageBox.Show("A user is already logged in.");
            //}
        //}

        //private void ClearText(int i)
        //{
        //    switch (i)
        //    {
        //        case 0:
        //            usernameText.Text = "";
        //            usernameError.Visible = true;
        //            break;
        //        case 1:
        //            passwordText.Text = "";
        //            passwordError.Visible = true;
        //            break;
        //        case 2:
        //            usernameText.Text = "";
        //            passwordText.Text = "";
        //            usernameError.Visible = true;
        //            passwordError.Visible = true;
        //            break;
        //    }
        //}

        //new starts
        // Dictionary to store translations
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

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text.Trim();
            string password = passwordText.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(translations[currentLanguage]["errorEmptyFields"],
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
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
                    MessageBox.Show(translations[currentLanguage]["successLogin"] + username,
                                    this.Text,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Check for upcoming appointments
                    //CheckUpcomingAppointments(username);

                    // Open main form
                    this.Hide();
                    new Home(username).ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(translations[currentLanguage]["errorInvalidCredentials"],
                                    this.Text,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ClearText(2);
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

        private bool VerifyLogin(string username, string password)
        {
            // For the project requirement, we use "test" as both username and password
            if (username == "test" && password == "test")
            {
                return true;
            }

            // Additionally, verify against the database
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

        private void ClearText(int i)
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
        }
}
