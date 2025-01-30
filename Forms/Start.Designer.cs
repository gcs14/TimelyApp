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
            loginBtn_Start = new System.Windows.Forms.Label();
            registerBtn_Start = new System.Windows.Forms.Label();
            enterBtn = new System.Windows.Forms.Button();
            myScheduleLabel = new System.Windows.Forms.Label();
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
            // loginBtn_Start
            // 
            loginBtn_Start.AutoSize = true;
            loginBtn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            loginBtn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            loginBtn_Start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            loginBtn_Start.Location = new System.Drawing.Point(869, 10);
            loginBtn_Start.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loginBtn_Start.Name = "loginBtn_Start";
            loginBtn_Start.Size = new System.Drawing.Size(47, 18);
            loginBtn_Start.TabIndex = 2;
            loginBtn_Start.Text = "Login";
            loginBtn_Start.Click += loginBtn_Start_Click;
            // 
            // registerBtn_Start
            // 
            registerBtn_Start.AutoSize = true;
            registerBtn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            registerBtn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            registerBtn_Start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            registerBtn_Start.Location = new System.Drawing.Point(774, 10);
            registerBtn_Start.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            registerBtn_Start.Name = "registerBtn_Start";
            registerBtn_Start.Size = new System.Drawing.Size(67, 18);
            registerBtn_Start.TabIndex = 1;
            registerBtn_Start.Text = "Register";
            registerBtn_Start.Click += registerBtn_Start_Click;
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
            // Start
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Cornsilk;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(enterBtn);
            Controls.Add(myScheduleLabel);
            Controls.Add(registerBtn_Start);
            Controls.Add(loginBtn_Start);
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
        private System.Windows.Forms.Label loginBtn_Start;
        private System.Windows.Forms.Label registerBtn_Start;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.Label myScheduleLabel;
    }
}

