namespace DesktopSchedulingApp.Forms
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            welcomePic_Login = new System.Windows.Forms.PictureBox();
            loginBtn_Register = new System.Windows.Forms.Label();
            passwordLabel_Login = new System.Windows.Forms.Label();
            usernameLabel_Login = new System.Windows.Forms.Label();
            loginSubmitBtn = new System.Windows.Forms.Button();
            password_Login = new System.Windows.Forms.TextBox();
            username_Login = new System.Windows.Forms.TextBox();
            welcomeLabel_Login = new System.Windows.Forms.Label();
            startBtn_Register = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)welcomePic_Login).BeginInit();
            SuspendLayout();
            // 
            // welcomePic_Login
            // 
            welcomePic_Login.Image = Properties.Resources.AdobeStock_415962900_scaled_1;
            welcomePic_Login.InitialImage = (System.Drawing.Image)resources.GetObject("welcomePic_Login.InitialImage");
            welcomePic_Login.Location = new System.Drawing.Point(14, 45);
            welcomePic_Login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            welcomePic_Login.Name = "welcomePic_Login";
            welcomePic_Login.Size = new System.Drawing.Size(622, 438);
            welcomePic_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            welcomePic_Login.TabIndex = 2;
            welcomePic_Login.TabStop = false;
            // 
            // loginBtn_Register
            // 
            loginBtn_Register.AutoSize = true;
            loginBtn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            loginBtn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            loginBtn_Register.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline);
            loginBtn_Register.Location = new System.Drawing.Point(870, 10);
            loginBtn_Register.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loginBtn_Register.Name = "loginBtn_Register";
            loginBtn_Register.Size = new System.Drawing.Size(47, 18);
            loginBtn_Register.TabIndex = 10;
            loginBtn_Register.Text = "Login";
            loginBtn_Register.Click += loginBtn_Register_Click;
            // 
            // passwordLabel_Login
            // 
            passwordLabel_Login.AutoSize = true;
            passwordLabel_Login.Font = new System.Drawing.Font("Cambria", 12F);
            passwordLabel_Login.Location = new System.Drawing.Point(668, 264);
            passwordLabel_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            passwordLabel_Login.Name = "passwordLabel_Login";
            passwordLabel_Login.Size = new System.Drawing.Size(77, 19);
            passwordLabel_Login.TabIndex = 15;
            passwordLabel_Login.Text = "Password";
            // 
            // usernameLabel_Login
            // 
            usernameLabel_Login.AutoSize = true;
            usernameLabel_Login.Font = new System.Drawing.Font("Cambria", 12F);
            usernameLabel_Login.Location = new System.Drawing.Point(668, 188);
            usernameLabel_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            usernameLabel_Login.Name = "usernameLabel_Login";
            usernameLabel_Login.Size = new System.Drawing.Size(79, 19);
            usernameLabel_Login.TabIndex = 16;
            usernameLabel_Login.Text = "Username";
            // 
            // loginSubmitBtn
            // 
            loginSubmitBtn.AutoSize = true;
            loginSubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            loginSubmitBtn.BackColor = System.Drawing.Color.Tan;
            loginSubmitBtn.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            loginSubmitBtn.Location = new System.Drawing.Point(799, 345);
            loginSubmitBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loginSubmitBtn.Name = "loginSubmitBtn";
            loginSubmitBtn.Size = new System.Drawing.Size(82, 33);
            loginSubmitBtn.TabIndex = 14;
            loginSubmitBtn.Text = "Submit";
            loginSubmitBtn.UseVisualStyleBackColor = false;
            // 
            // password_Login
            // 
            password_Login.AcceptsReturn = true;
            password_Login.AcceptsTab = true;
            password_Login.Font = new System.Drawing.Font("Segoe UI", 11F);
            password_Login.Location = new System.Drawing.Point(672, 286);
            password_Login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            password_Login.Name = "password_Login";
            password_Login.PasswordChar = '*';
            password_Login.Size = new System.Drawing.Size(209, 27);
            password_Login.TabIndex = 12;
            // 
            // username_Login
            // 
            username_Login.AcceptsReturn = true;
            username_Login.AcceptsTab = true;
            username_Login.Font = new System.Drawing.Font("Segoe UI", 11F);
            username_Login.Location = new System.Drawing.Point(672, 210);
            username_Login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            username_Login.Name = "username_Login";
            username_Login.Size = new System.Drawing.Size(209, 27);
            username_Login.TabIndex = 13;
            // 
            // welcomeLabel_Login
            // 
            welcomeLabel_Login.AutoSize = true;
            welcomeLabel_Login.Font = new System.Drawing.Font("Cambria", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            welcomeLabel_Login.Location = new System.Drawing.Point(644, 114);
            welcomeLabel_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            welcomeLabel_Login.Name = "welcomeLabel_Login";
            welcomeLabel_Login.Size = new System.Drawing.Size(282, 44);
            welcomeLabel_Login.TabIndex = 11;
            welcomeLabel_Login.Text = "Create Account";
            // 
            // startBtn_Register
            // 
            startBtn_Register.AutoSize = true;
            startBtn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            startBtn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            startBtn_Register.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline);
            startBtn_Register.Location = new System.Drawing.Point(14, 10);
            startBtn_Register.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            startBtn_Register.Name = "startBtn_Register";
            startBtn_Register.Size = new System.Drawing.Size(54, 18);
            startBtn_Register.TabIndex = 17;
            startBtn_Register.Text = "< Start";
            startBtn_Register.Click += startBtn_Register_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Cornsilk;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(startBtn_Register);
            Controls.Add(passwordLabel_Login);
            Controls.Add(usernameLabel_Login);
            Controls.Add(loginSubmitBtn);
            Controls.Add(password_Login);
            Controls.Add(username_Login);
            Controls.Add(welcomeLabel_Login);
            Controls.Add(loginBtn_Register);
            Controls.Add(welcomePic_Login);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Register";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)welcomePic_Login).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePic_Login;
        private System.Windows.Forms.Label loginBtn_Register;
        private System.Windows.Forms.Label passwordLabel_Login;
        private System.Windows.Forms.Label usernameLabel_Login;
        private System.Windows.Forms.Button loginSubmitBtn;
        private System.Windows.Forms.TextBox password_Login;
        private System.Windows.Forms.TextBox username_Login;
        private System.Windows.Forms.Label welcomeLabel_Login;
        private System.Windows.Forms.Label startBtn_Register;
    }
}