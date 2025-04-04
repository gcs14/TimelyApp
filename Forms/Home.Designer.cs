﻿namespace DesktopSchedulingApp.Forms
{
    partial class Home
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            calendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            monthlyAppointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            userScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            welcomeLabel = new System.Windows.Forms.Label();
            peakHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { customerToolStripMenuItem, appointmentsToolStripMenuItem, calendarToolStripMenuItem, reportsToolStripMenuItem, toolStripMenuItem2, toolStripMenuItem4, logoutToolStripMenuItem, quitToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(793, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            customerToolStripMenuItem.Text = "Customers";
            customerToolStripMenuItem.Click += CustomerBtn_Click;
            // 
            // appointmentsToolStripMenuItem
            // 
            appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            appointmentsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            appointmentsToolStripMenuItem.Text = "Appointments";
            appointmentsToolStripMenuItem.Click += AppointmentBtn_Click;
            // 
            // calendarToolStripMenuItem
            // 
            calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            calendarToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            calendarToolStripMenuItem.Text = "Calendar";
            calendarToolStripMenuItem.Click += calendarBtn_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { monthlyAppointmentsToolStripMenuItem, userScheduleToolStripMenuItem, peakHoursToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // monthlyAppointmentsToolStripMenuItem
            // 
            monthlyAppointmentsToolStripMenuItem.Name = "monthlyAppointmentsToolStripMenuItem";
            monthlyAppointmentsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            monthlyAppointmentsToolStripMenuItem.Text = "Monthly Appointments";
            monthlyAppointmentsToolStripMenuItem.Click += monthlyAppointmentsBtn_Click;
            // 
            // userScheduleToolStripMenuItem
            // 
            userScheduleToolStripMenuItem.Name = "userScheduleToolStripMenuItem";
            userScheduleToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            userScheduleToolStripMenuItem.Text = "User Schedule";
            userScheduleToolStripMenuItem.Click += userScheduleBtn_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(196, 20);
            toolStripMenuItem2.Text = "                                                           ";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Enabled = false;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(157, 20);
            toolStripMenuItem4.Text = "                                              ";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            logoutToolStripMenuItem.Text = "Logout";
            logoutToolStripMenuItem.Click += logoutBtn_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitBtn_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new System.Drawing.Font("Arial Black", 50F);
            welcomeLabel.ForeColor = System.Drawing.SystemColors.Window;
            welcomeLabel.Location = new System.Drawing.Point(97, 175);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new System.Drawing.Size(582, 95);
            welcomeLabel.TabIndex = 10;
            welcomeLabel.Text = "Welcome Back";
            welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // peakHoursToolStripMenuItem
            // 
            peakHoursToolStripMenuItem.Name = "peakHoursToolStripMenuItem";
            peakHoursToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            peakHoursToolStripMenuItem.Text = "Peak Hours";
            peakHoursToolStripMenuItem.Click += peakHoursBtn_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(793, 510);
            Controls.Add(welcomeLabel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "Dashboard";
            Load += Home_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarToolStripMenuItem;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem monthlyAppointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peakHoursToolStripMenuItem;
    }
}