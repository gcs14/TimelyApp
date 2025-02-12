namespace DesktopSchedulingApp.Forms
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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { customerToolStripMenuItem, appointmentsToolStripMenuItem, calendarToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1165, 24);
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
            // 
            // calendarToolStripMenuItem
            // 
            calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            calendarToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            calendarToolStripMenuItem.Text = "Calendar";
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // Home
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1165, 751);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "Dashboard";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
    }
}