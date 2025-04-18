﻿namespace DesktopSchedulingApp.Forms.ReportForms
{
    partial class PeakHours
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
            peakHoursLabel = new System.Windows.Forms.Label();
            firstLabel = new System.Windows.Forms.Label();
            thirdLabel = new System.Windows.Forms.Label();
            CancelBtn = new System.Windows.Forms.Button();
            secondLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // peakHoursLabel
            // 
            peakHoursLabel.Dock = System.Windows.Forms.DockStyle.Top;
            peakHoursLabel.Font = new System.Drawing.Font("Arial Black", 35F);
            peakHoursLabel.ForeColor = System.Drawing.Color.MediumPurple;
            peakHoursLabel.Location = new System.Drawing.Point(0, 0);
            peakHoursLabel.Name = "peakHoursLabel";
            peakHoursLabel.Size = new System.Drawing.Size(374, 85);
            peakHoursLabel.TabIndex = 11;
            peakHoursLabel.Text = "Peak Hours";
            peakHoursLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstLabel
            // 
            firstLabel.AutoSize = true;
            firstLabel.ForeColor = System.Drawing.SystemColors.Window;
            firstLabel.Location = new System.Drawing.Point(80, 121);
            firstLabel.Name = "firstLabel";
            firstLabel.Size = new System.Drawing.Size(33, 20);
            firstLabel.TabIndex = 12;
            firstLabel.Text = "#1: ";
            // 
            // thirdLabel
            // 
            thirdLabel.AutoSize = true;
            thirdLabel.ForeColor = System.Drawing.SystemColors.Window;
            thirdLabel.Location = new System.Drawing.Point(80, 185);
            thirdLabel.Name = "thirdLabel";
            thirdLabel.Size = new System.Drawing.Size(29, 20);
            thirdLabel.TabIndex = 12;
            thirdLabel.Text = "#3:";
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.BackColor = System.Drawing.Color.MediumPurple;
            CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CancelBtn.Font = new System.Drawing.Font("Arial", 11F);
            CancelBtn.Location = new System.Drawing.Point(274, 233);
            CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new System.Drawing.Size(88, 43);
            CancelBtn.TabIndex = 13;
            CancelBtn.Text = "Close";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // secondLabel
            // 
            secondLabel.AutoSize = true;
            secondLabel.ForeColor = System.Drawing.SystemColors.Window;
            secondLabel.Location = new System.Drawing.Point(80, 153);
            secondLabel.Name = "secondLabel";
            secondLabel.Size = new System.Drawing.Size(33, 20);
            secondLabel.TabIndex = 12;
            secondLabel.Text = "#2: ";
            // 
            // PeakHours
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(374, 295);
            Controls.Add(CancelBtn);
            Controls.Add(secondLabel);
            Controls.Add(thirdLabel);
            Controls.Add(firstLabel);
            Controls.Add(peakHoursLabel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "PeakHours";
            Text = "Peak Hours";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label peakHoursLabel;
        private System.Windows.Forms.Label firstLabel;
        private System.Windows.Forms.Label thirdLabel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label secondLabel;
    }
}