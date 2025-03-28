namespace DesktopSchedulingApp.Forms.ReportForms
{
    partial class UserSchedule
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
            scheduleDGV = new System.Windows.Forms.DataGridView();
            addAppoinmentLabel = new System.Windows.Forms.Label();
            CancelBtn = new System.Windows.Forms.Button();
            timeZoneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)scheduleDGV).BeginInit();
            SuspendLayout();
            // 
            // scheduleDGV
            // 
            scheduleDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            scheduleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scheduleDGV.Location = new System.Drawing.Point(15, 138);
            scheduleDGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            scheduleDGV.MultiSelect = false;
            scheduleDGV.Name = "scheduleDGV";
            scheduleDGV.ReadOnly = true;
            scheduleDGV.RowHeadersVisible = false;
            scheduleDGV.RowHeadersWidth = 51;
            scheduleDGV.Size = new System.Drawing.Size(406, 260);
            scheduleDGV.TabIndex = 0;
            // 
            // addAppoinmentLabel
            // 
            addAppoinmentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            addAppoinmentLabel.Font = new System.Drawing.Font("Arial Black", 40F);
            addAppoinmentLabel.ForeColor = System.Drawing.Color.MediumPurple;
            addAppoinmentLabel.Location = new System.Drawing.Point(0, 0);
            addAppoinmentLabel.Name = "addAppoinmentLabel";
            addAppoinmentLabel.Size = new System.Drawing.Size(433, 85);
            addAppoinmentLabel.TabIndex = 10;
            addAppoinmentLabel.Text = "Schedule";
            addAppoinmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.BackColor = System.Drawing.Color.MediumPurple;
            CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CancelBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            CancelBtn.Location = new System.Drawing.Point(334, 423);
            CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new System.Drawing.Size(86, 43);
            CancelBtn.TabIndex = 11;
            CancelBtn.Text = "Close";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // timeZoneLabel
            // 
            timeZoneLabel.AutoSize = true;
            timeZoneLabel.ForeColor = System.Drawing.SystemColors.Window;
            timeZoneLabel.Location = new System.Drawing.Point(12, 114);
            timeZoneLabel.Name = "timeZoneLabel";
            timeZoneLabel.Size = new System.Drawing.Size(139, 20);
            timeZoneLabel.TabIndex = 12;
            timeZoneLabel.Text = "Current Time Zone: ";
            // 
            // UserSchedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(433, 481);
            Controls.Add(timeZoneLabel);
            Controls.Add(CancelBtn);
            Controls.Add(addAppoinmentLabel);
            Controls.Add(scheduleDGV);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "UserSchedule";
            Text = "UserSchedule";
            ((System.ComponentModel.ISupportInitialize)scheduleDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView scheduleDGV;
        private System.Windows.Forms.Label addAppoinmentLabel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label timeZoneLabel;
    }
}