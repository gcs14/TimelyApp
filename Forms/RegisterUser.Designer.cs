namespace DesktopSchedulingApp.Forms
{
    partial class RegisterUser
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
            loginLabel = new System.Windows.Forms.Label();
            usernameText_Reg = new System.Windows.Forms.TextBox();
            passwordText1_Reg = new System.Windows.Forms.TextBox();
            usernameError = new System.Windows.Forms.Label();
            passwordError1 = new System.Windows.Forms.Label();
            passwordLabel1 = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            passwordLabel2 = new System.Windows.Forms.Label();
            passwordError2 = new System.Windows.Forms.Label();
            passwordText2_Reg = new System.Windows.Forms.TextBox();
            submitBtn = new System.Windows.Forms.Button();
            cancelBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // loginLabel
            // 
            loginLabel.Dock = System.Windows.Forms.DockStyle.Top;
            loginLabel.Font = new System.Drawing.Font("Arial Black", 40F);
            loginLabel.ForeColor = System.Drawing.Color.MediumPurple;
            loginLabel.Location = new System.Drawing.Point(0, 0);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new System.Drawing.Size(553, 144);
            loginLabel.TabIndex = 0;
            loginLabel.Text = "REGISTER";
            loginLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // usernameText_Reg
            // 
            usernameText_Reg.Font = new System.Drawing.Font("Segoe UI", 12F);
            usernameText_Reg.Location = new System.Drawing.Point(171, 209);
            usernameText_Reg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            usernameText_Reg.Name = "usernameText_Reg";
            usernameText_Reg.Size = new System.Drawing.Size(215, 34);
            usernameText_Reg.TabIndex = 1;
            // 
            // passwordText1_Reg
            // 
            passwordText1_Reg.Font = new System.Drawing.Font("Segoe UI", 12F);
            passwordText1_Reg.Location = new System.Drawing.Point(171, 321);
            passwordText1_Reg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            passwordText1_Reg.Name = "passwordText1_Reg";
            passwordText1_Reg.PasswordChar = '*';
            passwordText1_Reg.Size = new System.Drawing.Size(215, 34);
            passwordText1_Reg.TabIndex = 2;
            // 
            // usernameError
            // 
            usernameError.AutoSize = true;
            usernameError.Font = new System.Drawing.Font("Arial Black", 12F);
            usernameError.ForeColor = System.Drawing.Color.Red;
            usernameError.Location = new System.Drawing.Point(363, 177);
            usernameError.Name = "usernameError";
            usernameError.Size = new System.Drawing.Size(23, 28);
            usernameError.TabIndex = 10;
            usernameError.Text = "*";
            usernameError.Visible = false;
            // 
            // passwordError1
            // 
            passwordError1.AutoSize = true;
            passwordError1.Font = new System.Drawing.Font("Arial Black", 12F);
            passwordError1.ForeColor = System.Drawing.Color.Red;
            passwordError1.Location = new System.Drawing.Point(363, 287);
            passwordError1.Name = "passwordError1";
            passwordError1.Size = new System.Drawing.Size(23, 28);
            passwordError1.TabIndex = 11;
            passwordError1.Text = "*";
            passwordError1.Visible = false;
            // 
            // passwordLabel1
            // 
            passwordLabel1.AutoSize = true;
            passwordLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            passwordLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            passwordLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            passwordLabel1.Location = new System.Drawing.Point(168, 292);
            passwordLabel1.Name = "passwordLabel1";
            passwordLabel1.Size = new System.Drawing.Size(99, 23);
            passwordLabel1.TabIndex = 0;
            passwordLabel1.Text = "PASSWORD";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            usernameLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            usernameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            usernameLabel.Location = new System.Drawing.Point(168, 180);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(98, 23);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "USERNAME";
            // 
            // passwordLabel2
            // 
            passwordLabel2.AutoSize = true;
            passwordLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            passwordLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            passwordLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            passwordLabel2.Location = new System.Drawing.Point(168, 407);
            passwordLabel2.Name = "passwordLabel2";
            passwordLabel2.Size = new System.Drawing.Size(179, 23);
            passwordLabel2.TabIndex = 0;
            passwordLabel2.Text = "CONFIRM PASSWORD";
            // 
            // passwordError2
            // 
            passwordError2.AutoSize = true;
            passwordError2.Font = new System.Drawing.Font("Arial Black", 12F);
            passwordError2.ForeColor = System.Drawing.Color.Red;
            passwordError2.Location = new System.Drawing.Point(363, 401);
            passwordError2.Name = "passwordError2";
            passwordError2.Size = new System.Drawing.Size(23, 28);
            passwordError2.TabIndex = 11;
            passwordError2.Text = "*";
            passwordError2.Visible = false;
            // 
            // passwordText2_Reg
            // 
            passwordText2_Reg.Font = new System.Drawing.Font("Segoe UI", 12F);
            passwordText2_Reg.Location = new System.Drawing.Point(171, 436);
            passwordText2_Reg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            passwordText2_Reg.Name = "passwordText2_Reg";
            passwordText2_Reg.PasswordChar = '*';
            passwordText2_Reg.Size = new System.Drawing.Size(215, 34);
            passwordText2_Reg.TabIndex = 3;
            // 
            // submitBtn
            // 
            submitBtn.AutoSize = true;
            submitBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            submitBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            submitBtn.Font = new System.Drawing.Font("Arial", 11F);
            submitBtn.Location = new System.Drawing.Point(171, 547);
            submitBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new System.Drawing.Size(94, 34);
            submitBtn.TabIndex = 4;
            submitBtn.Text = "SUBMIT";
            submitBtn.UseVisualStyleBackColor = false;
            submitBtn.Click += RegisterBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.AutoSize = true;
            cancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            cancelBtn.BackColor = System.Drawing.Color.Red;
            cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cancelBtn.Font = new System.Drawing.Font("Arial", 11F);
            cancelBtn.Location = new System.Drawing.Point(297, 547);
            cancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new System.Drawing.Size(100, 34);
            cancelBtn.TabIndex = 5;
            cancelBtn.Text = "CANCEL";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // RegisterUser
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(553, 615);
            Controls.Add(cancelBtn);
            Controls.Add(submitBtn);
            Controls.Add(usernameText_Reg);
            Controls.Add(passwordText2_Reg);
            Controls.Add(passwordText1_Reg);
            Controls.Add(passwordError2);
            Controls.Add(usernameError);
            Controls.Add(passwordLabel2);
            Controls.Add(passwordError1);
            Controls.Add(passwordLabel1);
            Controls.Add(usernameLabel);
            Controls.Add(loginLabel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "RegisterUser";
            Text = "RegisterUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel1;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel2;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
        internal System.Windows.Forms.TextBox usernameText_Reg;
        internal System.Windows.Forms.TextBox passwordText1_Reg;
        internal System.Windows.Forms.TextBox passwordText2_Reg;
        internal System.Windows.Forms.Label usernameError;
        internal System.Windows.Forms.Label passwordError1;
        internal System.Windows.Forms.Label passwordError2;
    }
}