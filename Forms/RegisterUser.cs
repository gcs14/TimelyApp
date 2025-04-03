using DesktopSchedulingApp.Service;
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

            UserService.AddUser(this, username, password, confirmPassword);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            UserService.CloseRegistrationForm(this);
        }
    }
}
