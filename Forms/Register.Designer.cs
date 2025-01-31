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
            welcomePic_Register = new System.Windows.Forms.PictureBox();
            loginBtn_Register = new System.Windows.Forms.Label();
            passwordLabel_Register = new System.Windows.Forms.Label();
            usernameLabel_Register = new System.Windows.Forms.Label();
            RegisterSubmitBtn = new System.Windows.Forms.Button();
            password_Register = new System.Windows.Forms.TextBox();
            username_Register = new System.Windows.Forms.TextBox();
            createAccountLabel = new System.Windows.Forms.Label();
            startBtn_Register = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)welcomePic_Register).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // welcomePic_Register
            // 
            welcomePic_Register.Image = Properties.Resources.AdobeStock_415962900_scaled_1;
            welcomePic_Register.InitialImage = (System.Drawing.Image)resources.GetObject("welcomePic_Register.InitialImage");
            welcomePic_Register.Location = new System.Drawing.Point(14, 45);
            welcomePic_Register.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            welcomePic_Register.Name = "welcomePic_Register";
            welcomePic_Register.Size = new System.Drawing.Size(622, 438);
            welcomePic_Register.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            welcomePic_Register.TabIndex = 2;
            welcomePic_Register.TabStop = false;
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
            // passwordLabel_Register
            // 
            passwordLabel_Register.AutoSize = true;
            passwordLabel_Register.Font = new System.Drawing.Font("Cambria", 12F);
            passwordLabel_Register.Location = new System.Drawing.Point(668, 264);
            passwordLabel_Register.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            passwordLabel_Register.Name = "passwordLabel_Register";
            passwordLabel_Register.Size = new System.Drawing.Size(77, 19);
            passwordLabel_Register.TabIndex = 15;
            passwordLabel_Register.Text = "Password";
            // 
            // usernameLabel_Register
            // 
            usernameLabel_Register.AutoSize = true;
            usernameLabel_Register.Font = new System.Drawing.Font("Cambria", 12F);
            usernameLabel_Register.Location = new System.Drawing.Point(668, 188);
            usernameLabel_Register.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            usernameLabel_Register.Name = "usernameLabel_Register";
            usernameLabel_Register.Size = new System.Drawing.Size(79, 19);
            usernameLabel_Register.TabIndex = 16;
            usernameLabel_Register.Text = "Username";
            // 
            // RegisterSubmitBtn
            // 
            RegisterSubmitBtn.AutoSize = true;
            RegisterSubmitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            RegisterSubmitBtn.BackColor = System.Drawing.Color.Tan;
            RegisterSubmitBtn.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            RegisterSubmitBtn.Location = new System.Drawing.Point(799, 345);
            RegisterSubmitBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RegisterSubmitBtn.Name = "RegisterSubmitBtn";
            RegisterSubmitBtn.Size = new System.Drawing.Size(82, 33);
            RegisterSubmitBtn.TabIndex = 14;
            RegisterSubmitBtn.Text = "Submit";
            RegisterSubmitBtn.UseVisualStyleBackColor = false;
            // 
            // password_Register
            // 
            password_Register.AcceptsReturn = true;
            password_Register.AcceptsTab = true;
            password_Register.Font = new System.Drawing.Font("Segoe UI", 11F);
            password_Register.Location = new System.Drawing.Point(672, 286);
            password_Register.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            password_Register.Name = "password_Register";
            password_Register.PasswordChar = '*';
            password_Register.Size = new System.Drawing.Size(209, 27);
            password_Register.TabIndex = 12;
            // 
            // username_Register
            // 
            username_Register.AcceptsReturn = true;
            username_Register.AcceptsTab = true;
            username_Register.Font = new System.Drawing.Font("Segoe UI", 11F);
            username_Register.Location = new System.Drawing.Point(672, 210);
            username_Register.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            username_Register.Name = "username_Register";
            username_Register.Size = new System.Drawing.Size(209, 27);
            username_Register.TabIndex = 13;
            // 
            // createAccountLabel
            // 
            createAccountLabel.AutoSize = true;
            createAccountLabel.Font = new System.Drawing.Font("Cambria", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            createAccountLabel.Location = new System.Drawing.Point(644, 114);
            createAccountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            createAccountLabel.Name = "createAccountLabel";
            createAccountLabel.Size = new System.Drawing.Size(282, 44);
            createAccountLabel.TabIndex = 11;
            createAccountLabel.Text = "Create Account";
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
            // pictureBox1
            // 
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.hidden;
            pictureBox1.Location = new System.Drawing.Point(885, 286);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(32, 27);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            pictureBox1.Click += passwordHide_Register_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Cornsilk;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(pictureBox1);
            Controls.Add(startBtn_Register);
            Controls.Add(passwordLabel_Register);
            Controls.Add(usernameLabel_Register);
            Controls.Add(RegisterSubmitBtn);
            Controls.Add(password_Register);
            Controls.Add(username_Register);
            Controls.Add(createAccountLabel);
            Controls.Add(loginBtn_Register);
            Controls.Add(welcomePic_Register);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Register";
            Text = "Register";
            ((System.ComponentModel.ISupportInitialize)welcomePic_Register).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePic_Register;
        private System.Windows.Forms.Label loginBtn_Register;
        private System.Windows.Forms.Label passwordLabel_Register;
        private System.Windows.Forms.Label usernameLabel_Register;
        private System.Windows.Forms.Button RegisterSubmitBtn;
        private System.Windows.Forms.TextBox password_Register;
        private System.Windows.Forms.TextBox username_Register;
        private System.Windows.Forms.Label createAccountLabel;
        private System.Windows.Forms.Label startBtn_Register;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}