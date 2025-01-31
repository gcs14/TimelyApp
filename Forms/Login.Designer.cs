namespace DesktopSchedulingApp.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            welcomeLabel_Login = new System.Windows.Forms.Label();
            username_Login = new System.Windows.Forms.TextBox();
            password_Login = new System.Windows.Forms.TextBox();
            loginSubmitBtn = new System.Windows.Forms.Button();
            usernameLabel_Login = new System.Windows.Forms.Label();
            passwordLabel_Login = new System.Windows.Forms.Label();
            registerBtn_Login = new System.Windows.Forms.Label();
            welcomePic_Login = new System.Windows.Forms.PictureBox();
            startBtn_Login = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)welcomePic_Login).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // welcomeLabel_Login
            // 
            welcomeLabel_Login.AutoSize = true;
            welcomeLabel_Login.Font = new System.Drawing.Font("Cambria", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            welcomeLabel_Login.Location = new System.Drawing.Point(644, 114);
            welcomeLabel_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            welcomeLabel_Login.Name = "welcomeLabel_Login";
            welcomeLabel_Login.Size = new System.Drawing.Size(286, 44);
            welcomeLabel_Login.TabIndex = 3;
            welcomeLabel_Login.Text = "Welcome Back!";
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
            username_Login.TabIndex = 1;
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
            password_Login.TabIndex = 2;
            // 
            // loginSubmitBtn
            // 
            loginSubmitBtn.AutoSize = true;
            loginSubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            loginSubmitBtn.BackColor = System.Drawing.Color.Tan;
            loginSubmitBtn.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            loginSubmitBtn.Location = new System.Drawing.Point(799, 346);
            loginSubmitBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loginSubmitBtn.Name = "loginSubmitBtn";
            loginSubmitBtn.Size = new System.Drawing.Size(82, 33);
            loginSubmitBtn.TabIndex = 3;
            loginSubmitBtn.Text = "Submit";
            loginSubmitBtn.UseVisualStyleBackColor = false;
            loginSubmitBtn.Click += loginSubmitBtn_Click;
            // 
            // usernameLabel_Login
            // 
            usernameLabel_Login.AutoSize = true;
            usernameLabel_Login.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            usernameLabel_Login.Location = new System.Drawing.Point(668, 188);
            usernameLabel_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            usernameLabel_Login.Name = "usernameLabel_Login";
            usernameLabel_Login.Size = new System.Drawing.Size(79, 19);
            usernameLabel_Login.TabIndex = 6;
            usernameLabel_Login.Text = "Username";
            // 
            // passwordLabel_Login
            // 
            passwordLabel_Login.AutoSize = true;
            passwordLabel_Login.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            passwordLabel_Login.Location = new System.Drawing.Point(668, 264);
            passwordLabel_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            passwordLabel_Login.Name = "passwordLabel_Login";
            passwordLabel_Login.Size = new System.Drawing.Size(77, 19);
            passwordLabel_Login.TabIndex = 6;
            passwordLabel_Login.Text = "Password";
            // 
            // registerBtn_Login
            // 
            registerBtn_Login.AutoSize = true;
            registerBtn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            registerBtn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            registerBtn_Login.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            registerBtn_Login.Location = new System.Drawing.Point(853, 10);
            registerBtn_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            registerBtn_Login.Name = "registerBtn_Login";
            registerBtn_Login.Size = new System.Drawing.Size(67, 18);
            registerBtn_Login.TabIndex = 5;
            registerBtn_Login.Text = "Register";
            registerBtn_Login.Click += registerBtn_Login_Click;
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
            welcomePic_Login.TabIndex = 1;
            welcomePic_Login.TabStop = false;
            // 
            // startBtn_Login
            // 
            startBtn_Login.AutoSize = true;
            startBtn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            startBtn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            startBtn_Login.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            startBtn_Login.Location = new System.Drawing.Point(14, 10);
            startBtn_Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            startBtn_Login.Name = "startBtn_Login";
            startBtn_Login.Size = new System.Drawing.Size(54, 18);
            startBtn_Login.TabIndex = 4;
            startBtn_Login.Text = "< Start";
            startBtn_Login.Click += startBtn_Login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.hidden;
            pictureBox1.Location = new System.Drawing.Point(885, 286);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 27);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += passwordHide_Login_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Cornsilk;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(pictureBox1);
            Controls.Add(startBtn_Login);
            Controls.Add(registerBtn_Login);
            Controls.Add(passwordLabel_Login);
            Controls.Add(usernameLabel_Login);
            Controls.Add(loginSubmitBtn);
            Controls.Add(password_Login);
            Controls.Add(username_Login);
            Controls.Add(welcomeLabel_Login);
            Controls.Add(welcomePic_Login);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)welcomePic_Login).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePic_Login;
        private System.Windows.Forms.Label welcomeLabel_Login;
        private System.Windows.Forms.TextBox username_Login;
        private System.Windows.Forms.TextBox password_Login;
        private System.Windows.Forms.Button loginSubmitBtn;
        private System.Windows.Forms.Label usernameLabel_Login;
        private System.Windows.Forms.Label passwordLabel_Login;
        private System.Windows.Forms.Label registerBtn_Login;
        private System.Windows.Forms.Label startBtn_Login;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}