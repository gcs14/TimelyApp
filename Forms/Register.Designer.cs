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
            this.welcomePic_Login = new System.Windows.Forms.PictureBox();
            this.loginBtn_Register = new System.Windows.Forms.Label();
            this.passwordLabel_Login = new System.Windows.Forms.Label();
            this.usernameLabel_Login = new System.Windows.Forms.Label();
            this.loginSubmitBtn = new System.Windows.Forms.Button();
            this.password_Login = new System.Windows.Forms.TextBox();
            this.username_Login = new System.Windows.Forms.TextBox();
            this.welcomeLabel_Login = new System.Windows.Forms.Label();
            this.startBtn_Register = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePic_Login)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomePic_Login
            // 
            this.welcomePic_Login.Image = global::DesktopSchedulingApp.Properties.Resources.AdobeStock_415962900_scaled_1;
            this.welcomePic_Login.InitialImage = ((System.Drawing.Image)(resources.GetObject("welcomePic_Login.InitialImage")));
            this.welcomePic_Login.Location = new System.Drawing.Point(12, 39);
            this.welcomePic_Login.Name = "welcomePic_Login";
            this.welcomePic_Login.Size = new System.Drawing.Size(533, 380);
            this.welcomePic_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.welcomePic_Login.TabIndex = 2;
            this.welcomePic_Login.TabStop = false;
            // 
            // loginBtn_Register
            // 
            this.loginBtn_Register.AutoSize = true;
            this.loginBtn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginBtn_Register.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn_Register.Location = new System.Drawing.Point(746, 9);
            this.loginBtn_Register.Name = "loginBtn_Register";
            this.loginBtn_Register.Size = new System.Drawing.Size(42, 16);
            this.loginBtn_Register.TabIndex = 10;
            this.loginBtn_Register.Text = "Login";
            this.loginBtn_Register.Click += new System.EventHandler(this.loginBtn_Register_Click);
            // 
            // passwordLabel_Login
            // 
            this.passwordLabel_Login.AutoSize = true;
            this.passwordLabel_Login.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel_Login.Location = new System.Drawing.Point(573, 229);
            this.passwordLabel_Login.Name = "passwordLabel_Login";
            this.passwordLabel_Login.Size = new System.Drawing.Size(66, 16);
            this.passwordLabel_Login.TabIndex = 15;
            this.passwordLabel_Login.Text = "Password";
            // 
            // usernameLabel_Login
            // 
            this.usernameLabel_Login.AutoSize = true;
            this.usernameLabel_Login.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel_Login.Location = new System.Drawing.Point(573, 163);
            this.usernameLabel_Login.Name = "usernameLabel_Login";
            this.usernameLabel_Login.Size = new System.Drawing.Size(69, 16);
            this.usernameLabel_Login.TabIndex = 16;
            this.usernameLabel_Login.Text = "Username";
            // 
            // loginSubmitBtn
            // 
            this.loginSubmitBtn.AutoSize = true;
            this.loginSubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginSubmitBtn.BackColor = System.Drawing.Color.Tan;
            this.loginSubmitBtn.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSubmitBtn.Location = new System.Drawing.Point(695, 300);
            this.loginSubmitBtn.Name = "loginSubmitBtn";
            this.loginSubmitBtn.Size = new System.Drawing.Size(61, 26);
            this.loginSubmitBtn.TabIndex = 14;
            this.loginSubmitBtn.Text = "Submit";
            this.loginSubmitBtn.UseVisualStyleBackColor = false;
            // 
            // password_Login
            // 
            this.password_Login.AcceptsReturn = true;
            this.password_Login.AcceptsTab = true;
            this.password_Login.Location = new System.Drawing.Point(576, 248);
            this.password_Login.Name = "password_Login";
            this.password_Login.PasswordChar = '*';
            this.password_Login.Size = new System.Drawing.Size(180, 20);
            this.password_Login.TabIndex = 12;
            // 
            // username_Login
            // 
            this.username_Login.AcceptsReturn = true;
            this.username_Login.AcceptsTab = true;
            this.username_Login.Location = new System.Drawing.Point(576, 182);
            this.username_Login.Name = "username_Login";
            this.username_Login.Size = new System.Drawing.Size(180, 20);
            this.username_Login.TabIndex = 13;
            // 
            // welcomeLabel_Login
            // 
            this.welcomeLabel_Login.AutoSize = true;
            this.welcomeLabel_Login.Font = new System.Drawing.Font("Cambria", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel_Login.Location = new System.Drawing.Point(549, 100);
            this.welcomeLabel_Login.Name = "welcomeLabel_Login";
            this.welcomeLabel_Login.Size = new System.Drawing.Size(251, 40);
            this.welcomeLabel_Login.TabIndex = 11;
            this.welcomeLabel_Login.Text = "Create Account";
            // 
            // startBtn_Register
            // 
            this.startBtn_Register.AutoSize = true;
            this.startBtn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startBtn_Register.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn_Register.Location = new System.Drawing.Point(12, 9);
            this.startBtn_Register.Name = "startBtn_Register";
            this.startBtn_Register.Size = new System.Drawing.Size(49, 16);
            this.startBtn_Register.TabIndex = 17;
            this.startBtn_Register.Text = "< Start";
            this.startBtn_Register.Click += new System.EventHandler(this.startBtn_Register_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.startBtn_Register);
            this.Controls.Add(this.passwordLabel_Login);
            this.Controls.Add(this.usernameLabel_Login);
            this.Controls.Add(this.loginSubmitBtn);
            this.Controls.Add(this.password_Login);
            this.Controls.Add(this.username_Login);
            this.Controls.Add(this.welcomeLabel_Login);
            this.Controls.Add(this.loginBtn_Register);
            this.Controls.Add(this.welcomePic_Login);
            this.Name = "Register";
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.welcomePic_Login)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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