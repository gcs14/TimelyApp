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
            this.welcomePic_Login = new System.Windows.Forms.PictureBox();
            this.welcomeLabel_Login = new System.Windows.Forms.Label();
            this.username_Login = new System.Windows.Forms.TextBox();
            this.password_Login = new System.Windows.Forms.TextBox();
            this.loginSubmitBtn = new System.Windows.Forms.Button();
            this.usernameLabel_Login = new System.Windows.Forms.Label();
            this.passwordLabel_Login = new System.Windows.Forms.Label();
            this.registerBtn_Login = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.welcomePic_Login.TabIndex = 1;
            this.welcomePic_Login.TabStop = false;
            // 
            // welcomeLabel_Login
            // 
            this.welcomeLabel_Login.AutoSize = true;
            this.welcomeLabel_Login.Font = new System.Drawing.Font("Cambria", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel_Login.Location = new System.Drawing.Point(549, 100);
            this.welcomeLabel_Login.Name = "welcomeLabel_Login";
            this.welcomeLabel_Login.Size = new System.Drawing.Size(253, 40);
            this.welcomeLabel_Login.TabIndex = 3;
            this.welcomeLabel_Login.Text = "Welcome Back!";
            // 
            // username_Login
            // 
            this.username_Login.AcceptsReturn = true;
            this.username_Login.AcceptsTab = true;
            this.username_Login.Location = new System.Drawing.Point(576, 182);
            this.username_Login.Name = "username_Login";
            this.username_Login.Size = new System.Drawing.Size(180, 20);
            this.username_Login.TabIndex = 4;
            // 
            // password_Login
            // 
            this.password_Login.AcceptsReturn = true;
            this.password_Login.AcceptsTab = true;
            this.password_Login.Location = new System.Drawing.Point(576, 248);
            this.password_Login.Name = "password_Login";
            this.password_Login.PasswordChar = '*';
            this.password_Login.Size = new System.Drawing.Size(180, 20);
            this.password_Login.TabIndex = 4;
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
            this.loginSubmitBtn.TabIndex = 5;
            this.loginSubmitBtn.Text = "Submit";
            this.loginSubmitBtn.UseVisualStyleBackColor = false;
            this.loginSubmitBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // usernameLabel_Login
            // 
            this.usernameLabel_Login.AutoSize = true;
            this.usernameLabel_Login.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel_Login.Location = new System.Drawing.Point(573, 163);
            this.usernameLabel_Login.Name = "usernameLabel_Login";
            this.usernameLabel_Login.Size = new System.Drawing.Size(69, 16);
            this.usernameLabel_Login.TabIndex = 6;
            this.usernameLabel_Login.Text = "Username";
            // 
            // passwordLabel_Login
            // 
            this.passwordLabel_Login.AutoSize = true;
            this.passwordLabel_Login.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel_Login.Location = new System.Drawing.Point(573, 229);
            this.passwordLabel_Login.Name = "passwordLabel_Login";
            this.passwordLabel_Login.Size = new System.Drawing.Size(66, 16);
            this.passwordLabel_Login.TabIndex = 6;
            this.passwordLabel_Login.Text = "Password";
            // 
            // registerBtn_Login
            // 
            this.registerBtn_Login.AutoSize = true;
            this.registerBtn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.registerBtn_Login.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn_Login.Location = new System.Drawing.Point(726, 9);
            this.registerBtn_Login.Name = "registerBtn_Login";
            this.registerBtn_Login.Size = new System.Drawing.Size(60, 16);
            this.registerBtn_Login.TabIndex = 8;
            this.registerBtn_Login.Text = "Register";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "< Return";
            this.label1.Click += new System.EventHandler(this.previousBtn_Login);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registerBtn_Login);
            this.Controls.Add(this.passwordLabel_Login);
            this.Controls.Add(this.usernameLabel_Login);
            this.Controls.Add(this.loginSubmitBtn);
            this.Controls.Add(this.password_Login);
            this.Controls.Add(this.username_Login);
            this.Controls.Add(this.welcomeLabel_Login);
            this.Controls.Add(this.welcomePic_Login);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.welcomePic_Login)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
    }
}