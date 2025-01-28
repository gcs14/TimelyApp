namespace DesktopSchedulingApp
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.welcomePic = new System.Windows.Forms.PictureBox();
            this.welcomeLoginBtn = new System.Windows.Forms.Label();
            this.welcomeRegisterBtn = new System.Windows.Forms.Label();
            this.myScheduleLabel = new System.Windows.Forms.Label();
            this.enterBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.welcomePic)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomePic
            // 
            this.welcomePic.Image = global::DesktopSchedulingApp.Properties.Resources.AdobeStock_415962900_scaled_1;
            this.welcomePic.InitialImage = ((System.Drawing.Image)(resources.GetObject("welcomePic.InitialImage")));
            this.welcomePic.Location = new System.Drawing.Point(12, 39);
            this.welcomePic.Name = "welcomePic";
            this.welcomePic.Size = new System.Drawing.Size(533, 380);
            this.welcomePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.welcomePic.TabIndex = 0;
            this.welcomePic.TabStop = false;
            // 
            // welcomeLoginBtn
            // 
            this.welcomeLoginBtn.AutoSize = true;
            this.welcomeLoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.welcomeLoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.welcomeLoginBtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLoginBtn.Location = new System.Drawing.Point(745, 9);
            this.welcomeLoginBtn.Name = "welcomeLoginBtn";
            this.welcomeLoginBtn.Size = new System.Drawing.Size(42, 16);
            this.welcomeLoginBtn.TabIndex = 2;
            this.welcomeLoginBtn.Text = "Login";
            this.welcomeLoginBtn.Click += new System.EventHandler(this.loginBtn_Start_Click);
            // 
            // welcomeRegisterBtn
            // 
            this.welcomeRegisterBtn.AutoSize = true;
            this.welcomeRegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.welcomeRegisterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.welcomeRegisterBtn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeRegisterBtn.Location = new System.Drawing.Point(663, 9);
            this.welcomeRegisterBtn.Name = "welcomeRegisterBtn";
            this.welcomeRegisterBtn.Size = new System.Drawing.Size(60, 16);
            this.welcomeRegisterBtn.TabIndex = 1;
            this.welcomeRegisterBtn.Text = "Register";
            this.welcomeRegisterBtn.Click += new System.EventHandler(this.registerBtn_Start_Click);
            // 
            // myScheduleLabel
            // 
            this.myScheduleLabel.AutoSize = true;
            this.myScheduleLabel.Font = new System.Drawing.Font("Cambria", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myScheduleLabel.Location = new System.Drawing.Point(571, 170);
            this.myScheduleLabel.Name = "myScheduleLabel";
            this.myScheduleLabel.Size = new System.Drawing.Size(203, 40);
            this.myScheduleLabel.TabIndex = 2;
            this.myScheduleLabel.Text = "MySchedule";
            // 
            // enterBtn
            // 
            this.enterBtn.AutoSize = true;
            this.enterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.enterBtn.BackColor = System.Drawing.Color.Tan;
            this.enterBtn.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterBtn.Location = new System.Drawing.Point(642, 237);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(57, 29);
            this.enterBtn.TabIndex = 3;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = false;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Start_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.myScheduleLabel);
            this.Controls.Add(this.welcomeRegisterBtn);
            this.Controls.Add(this.welcomeLoginBtn);
            this.Controls.Add(this.welcomePic);
            this.Name = "Welcome";
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.welcomePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePic;
        private System.Windows.Forms.Label welcomeLoginBtn;
        private System.Windows.Forms.Label welcomeRegisterBtn;
        private System.Windows.Forms.Label myScheduleLabel;
        private System.Windows.Forms.Button enterBtn;
    }
}

