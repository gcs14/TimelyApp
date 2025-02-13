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
            usernameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            enterBtn = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            passwordError = new System.Windows.Forms.Label();
            usernameError = new System.Windows.Forms.Label();
            passwordText = new System.Windows.Forms.TextBox();
            usernameText = new System.Windows.Forms.TextBox();
            loginLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            usernameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            usernameLabel.Location = new System.Drawing.Point(162, 229);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(98, 23);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "USERNAME";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            passwordLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            passwordLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            passwordLabel.Location = new System.Drawing.Point(162, 341);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(99, 23);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "PASSWORD";
            // 
            // enterBtn
            // 
            enterBtn.AutoSize = true;
            enterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            enterBtn.BackColor = System.Drawing.Color.Silver;
            enterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            enterBtn.Font = new System.Drawing.Font("Arial", 11F);
            enterBtn.Location = new System.Drawing.Point(231, 460);
            enterBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            enterBtn.Name = "enterBtn";
            enterBtn.Size = new System.Drawing.Size(87, 34);
            enterBtn.TabIndex = 2;
            enterBtn.Text = "ENTER";
            enterBtn.UseVisualStyleBackColor = false;
            enterBtn.Click += EnterBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox1.Image = Properties.Resources.hidden;
            pictureBox1.Location = new System.Drawing.Point(389, 371);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(35, 39);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += passwordHide_Click;
            // 
            // passwordError
            // 
            passwordError.AutoSize = true;
            passwordError.Font = new System.Drawing.Font("Arial Black", 12F);
            passwordError.ForeColor = System.Drawing.Color.Red;
            passwordError.Location = new System.Drawing.Point(358, 336);
            passwordError.Name = "passwordError";
            passwordError.Size = new System.Drawing.Size(23, 28);
            passwordError.TabIndex = 4;
            passwordError.Text = "*";
            passwordError.Visible = false;
            // 
            // usernameError
            // 
            usernameError.AutoSize = true;
            usernameError.Font = new System.Drawing.Font("Arial Black", 12F);
            usernameError.ForeColor = System.Drawing.Color.Red;
            usernameError.Location = new System.Drawing.Point(358, 227);
            usernameError.Name = "usernameError";
            usernameError.Size = new System.Drawing.Size(23, 28);
            usernameError.TabIndex = 4;
            usernameError.Text = "*";
            usernameError.Visible = false;
            // 
            // passwordText
            // 
            passwordText.Font = new System.Drawing.Font("Segoe UI", 12F);
            passwordText.Location = new System.Drawing.Point(166, 371);
            passwordText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            passwordText.Name = "passwordText";
            passwordText.PasswordChar = '*';
            passwordText.Size = new System.Drawing.Size(215, 34);
            passwordText.TabIndex = 5;
            // 
            // usernameText
            // 
            usernameText.Font = new System.Drawing.Font("Segoe UI", 12F);
            usernameText.Location = new System.Drawing.Point(166, 259);
            usernameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            usernameText.Name = "usernameText";
            usernameText.Size = new System.Drawing.Size(215, 34);
            usernameText.TabIndex = 5;
            // 
            // loginLabel
            // 
            loginLabel.Dock = System.Windows.Forms.DockStyle.Top;
            loginLabel.Font = new System.Drawing.Font("Arial Black", 40F);
            loginLabel.ForeColor = System.Drawing.Color.MediumPurple;
            loginLabel.Location = new System.Drawing.Point(0, 0);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(553, 199);
            loginLabel.TabIndex = 6;
            loginLabel.Text = "LOGIN";
            loginLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(553, 615);
            Controls.Add(loginLabel);
            Controls.Add(usernameText);
            Controls.Add(passwordText);
            Controls.Add(usernameError);
            Controls.Add(passwordError);
            Controls.Add(pictureBox1);
            Controls.Add(enterBtn);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label passwordError;
        private System.Windows.Forms.Label usernameError;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label loginLabel;
    }
}