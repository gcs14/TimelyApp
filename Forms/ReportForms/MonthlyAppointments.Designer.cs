namespace DesktopSchedulingApp.Forms.ReportForms
{
    partial class MonthlyAppointments
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
            yearComboBox = new System.Windows.Forms.ComboBox();
            CancelBtn = new System.Windows.Forms.Button();
            addAppoinmentLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            monthReportDGV = new System.Windows.Forms.DataGridView();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)monthReportDGV).BeginInit();
            SuspendLayout();
            // 
            // yearComboBox
            // 
            yearComboBox.FormattingEnabled = true;
            yearComboBox.Location = new System.Drawing.Point(12, 78);
            yearComboBox.Name = "yearComboBox";
            yearComboBox.Size = new System.Drawing.Size(121, 23);
            yearComboBox.TabIndex = 0;
            yearComboBox.SelectedIndexChanged += yearComboBox_SelectedIndexChanged;
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.BackColor = System.Drawing.Color.MediumPurple;
            CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CancelBtn.Font = new System.Drawing.Font("Arial", 11F);
            CancelBtn.Location = new System.Drawing.Point(265, 319);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new System.Drawing.Size(77, 32);
            CancelBtn.TabIndex = 8;
            CancelBtn.Text = "CLOSE";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // addAppoinmentLabel
            // 
            addAppoinmentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            addAppoinmentLabel.Font = new System.Drawing.Font("Arial Black", 25F);
            addAppoinmentLabel.ForeColor = System.Drawing.Color.MediumPurple;
            addAppoinmentLabel.Location = new System.Drawing.Point(0, 0);
            addAppoinmentLabel.Name = "addAppoinmentLabel";
            addAppoinmentLabel.Size = new System.Drawing.Size(359, 64);
            addAppoinmentLabel.TabIndex = 9;
            addAppoinmentLabel.Text = "MONTHLY COUNT";
            addAppoinmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Location = new System.Drawing.Point(12, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 10;
            label1.Text = "Year:";
            // 
            // monthReportDGV
            // 
            monthReportDGV.AllowUserToAddRows = false;
            monthReportDGV.AllowUserToDeleteRows = false;
            monthReportDGV.AllowUserToResizeColumns = false;
            monthReportDGV.AllowUserToResizeRows = false;
            monthReportDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            monthReportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            monthReportDGV.Location = new System.Drawing.Point(13, 123);
            monthReportDGV.MultiSelect = false;
            monthReportDGV.Name = "monthReportDGV";
            monthReportDGV.ReadOnly = true;
            monthReportDGV.RowHeadersVisible = false;
            monthReportDGV.RowHeadersWidth = 51;
            monthReportDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            monthReportDGV.Size = new System.Drawing.Size(327, 166);
            monthReportDGV.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(179, 81);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 12;
            label2.Text = "label2";
            // 
            // MonthlyAppointments
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(359, 363);
            Controls.Add(label2);
            Controls.Add(monthReportDGV);
            Controls.Add(label1);
            Controls.Add(addAppoinmentLabel);
            Controls.Add(CancelBtn);
            Controls.Add(yearComboBox);
            Name = "MonthlyAppointments";
            Text = "MonthlyAppointments";
            ((System.ComponentModel.ISupportInitialize)monthReportDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label addAppoinmentLabel;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView monthReportDGV;
        private System.Windows.Forms.Label label2;
    }
}