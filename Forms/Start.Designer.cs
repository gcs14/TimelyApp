namespace DesktopSchedulingApp
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            welcomePic = new System.Windows.Forms.PictureBox();
            welcomeLoginBtn = new System.Windows.Forms.Label();
            welcomeRegisterBtn = new System.Windows.Forms.Label();
            myScheduleLabel = new System.Windows.Forms.Label();
            enterBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)welcomePic).BeginInit();
            SuspendLayout();
            // 
            // welcomePic
            // 
            welcomePic.Image = Properties.Resources.AdobeStock_415962900_scaled_1;
            welcomePic.InitialImage = (System.Drawing.Image)resources.GetObject("welcomePic.InitialImage");
            welcomePic.Location = new System.Drawing.Point(14, 45);
            welcomePic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            welcomePic.Name = "welcomePic";
            welcomePic.Size = new System.Drawing.Size(622, 438);
            welcomePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            welcomePic.TabIndex = 0;
            welcomePic.TabStop = false;
            // 
            // welcomeLoginBtn
            // 
            welcomeLoginBtn.AutoSize = true;
            welcomeLoginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            welcomeLoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            welcomeLoginBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            welcomeLoginBtn.Location = new System.Drawing.Point(869, 10);
            welcomeLoginBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            welcomeLoginBtn.Name = "welcomeLoginBtn";
            welcomeLoginBtn.Size = new System.Drawing.Size(47, 18);
            welcomeLoginBtn.TabIndex = 2;
            welcomeLoginBtn.Text = "Login";
            welcomeLoginBtn.Click += loginBtn_Start_Click;
            // 
            // welcomeRegisterBtn
            // 
            welcomeRegisterBtn.AutoSize = true;
            welcomeRegisterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            welcomeRegisterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            welcomeRegisterBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            welcomeRegisterBtn.Location = new System.Drawing.Point(774, 10);
            welcomeRegisterBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            welcomeRegisterBtn.Name = "welcomeRegisterBtn";
            welcomeRegisterBtn.Size = new System.Drawing.Size(67, 18);
            welcomeRegisterBtn.TabIndex = 1;
            welcomeRegisterBtn.Text = "Register";
            welcomeRegisterBtn.Click += registerBtn_Start_Click;
            // 
            // myScheduleLabel
            // 
            myScheduleLabel.AutoSize = true;
            myScheduleLabel.Font = new System.Drawing.Font("Cambria", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            myScheduleLabel.Location = new System.Drawing.Point(656, 200);
            myScheduleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            myScheduleLabel.Name = "myScheduleLabel";
            myScheduleLabel.Size = new System.Drawing.Size(264, 52);
            myScheduleLabel.TabIndex = 2;
            myScheduleLabel.Text = "MySchedule";
            // 
            // enterBtn
            // 
            enterBtn.AutoSize = true;
            enterBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            enterBtn.BackColor = System.Drawing.Color.Tan;
            enterBtn.Font = new System.Drawing.Font("Constantia", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            enterBtn.Location = new System.Drawing.Point(754, 279);
            enterBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            enterBtn.Name = "enterBtn";
            enterBtn.Size = new System.Drawing.Size(69, 34);
            enterBtn.TabIndex = 3;
            enterBtn.Text = "Enter";
            enterBtn.UseVisualStyleBackColor = false;
            enterBtn.Click += enterBtn_Start_Click;
            // 
            // Start
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Cornsilk;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(enterBtn);
            Controls.Add(myScheduleLabel);
            Controls.Add(welcomeRegisterBtn);
            Controls.Add(welcomeLoginBtn);
            Controls.Add(welcomePic);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Start";
            Text = "Start";
            Load += Start_Load;
            ((System.ComponentModel.ISupportInitialize)welcomePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox welcomePic;
        private System.Windows.Forms.Label welcomeLoginBtn;
        private System.Windows.Forms.Label welcomeRegisterBtn;
        private System.Windows.Forms.Label myScheduleLabel;
        private System.Windows.Forms.Button enterBtn;
    }
}

