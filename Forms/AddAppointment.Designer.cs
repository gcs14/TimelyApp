﻿namespace DesktopSchedulingApp.Forms
{
    partial class AddAppointment
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
            addAppoinmentLabel = new System.Windows.Forms.Label();
            custNamesDGV = new System.Windows.Forms.DataGridView();
            hoursDGV = new System.Windows.Forms.DataGridView();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            monthCalendar = new System.Windows.Forms.MonthCalendar();
            button1 = new System.Windows.Forms.Button();
            durationComboBox = new System.Windows.Forms.ComboBox();
            typeComboBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            addAppointment_Btn = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            CancelBtn = new System.Windows.Forms.Button();
            TimeZoneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)custNamesDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hoursDGV).BeginInit();
            SuspendLayout();
            // 
            // addAppoinmentLabel
            // 
            addAppoinmentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            addAppoinmentLabel.Font = new System.Drawing.Font("Arial Black", 31F);
            addAppoinmentLabel.ForeColor = System.Drawing.Color.MediumPurple;
            addAppoinmentLabel.Location = new System.Drawing.Point(0, 0);
            addAppoinmentLabel.Name = "addAppoinmentLabel";
            addAppoinmentLabel.Size = new System.Drawing.Size(578, 86);
            addAppoinmentLabel.TabIndex = 1;
            addAppoinmentLabel.Text = "NEW APPOINTMENT";
            addAppoinmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // custNamesDGV
            // 
            custNamesDGV.AllowUserToAddRows = false;
            custNamesDGV.AllowUserToDeleteRows = false;
            custNamesDGV.AllowUserToResizeColumns = false;
            custNamesDGV.AllowUserToResizeRows = false;
            custNamesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            custNamesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            custNamesDGV.Location = new System.Drawing.Point(438, 146);
            custNamesDGV.MultiSelect = false;
            custNamesDGV.Name = "custNamesDGV";
            custNamesDGV.ReadOnly = true;
            custNamesDGV.RowHeadersVisible = false;
            custNamesDGV.RowHeadersWidth = 51;
            custNamesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            custNamesDGV.Size = new System.Drawing.Size(120, 162);
            custNamesDGV.TabIndex = 4;
            // 
            // hoursDGV
            // 
            hoursDGV.AllowUserToAddRows = false;
            hoursDGV.AllowUserToDeleteRows = false;
            hoursDGV.AllowUserToResizeColumns = false;
            hoursDGV.AllowUserToResizeRows = false;
            hoursDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            hoursDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            hoursDGV.Location = new System.Drawing.Point(296, 146);
            hoursDGV.MultiSelect = false;
            hoursDGV.Name = "hoursDGV";
            hoursDGV.ReadOnly = true;
            hoursDGV.RowHeadersVisible = false;
            hoursDGV.RowHeadersWidth = 51;
            hoursDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            hoursDGV.Size = new System.Drawing.Size(120, 162);
            hoursDGV.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Location = new System.Drawing.Point(438, 121);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(96, 15);
            label1.TabIndex = 3;
            label1.Text = "Select Customer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.Window;
            label2.Location = new System.Drawing.Point(296, 121);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Select Time Slot:";
            // 
            // monthCalendar
            // 
            monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            monthCalendar.Location = new System.Drawing.Point(18, 145);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 1;
            monthCalendar.TrailingForeColor = System.Drawing.SystemColors.MenuHighlight;
            monthCalendar.DateSelected += MonthCalendar1_DateSelected;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(438, 311);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(120, 23);
            button1.TabIndex = 5;
            button1.Text = "New Customer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewCustomer_Click;
            // 
            // durationComboBox
            // 
            durationComboBox.FormattingEnabled = true;
            durationComboBox.Items.AddRange(new object[] { "30 Mins", "60 Mins" });
            durationComboBox.Location = new System.Drawing.Point(295, 311);
            durationComboBox.Name = "durationComboBox";
            durationComboBox.Size = new System.Drawing.Size(121, 23);
            durationComboBox.TabIndex = 3;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Items.AddRange(new object[] { "Presentation", "Scrum", "Consultation", "Other" });
            typeComboBox.Location = new System.Drawing.Point(18, 337);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new System.Drawing.Size(121, 23);
            typeComboBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.SystemColors.Window;
            label4.Location = new System.Drawing.Point(18, 319);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 15);
            label4.TabIndex = 3;
            label4.Text = "Type:";
            // 
            // addAppointment_Btn
            // 
            addAppointment_Btn.AutoSize = true;
            addAppointment_Btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            addAppointment_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            addAppointment_Btn.Font = new System.Drawing.Font("Segoe UI", 11F);
            addAppointment_Btn.Location = new System.Drawing.Point(459, 388);
            addAppointment_Btn.Name = "addAppointment_Btn";
            addAppointment_Btn.Size = new System.Drawing.Size(75, 32);
            addAppointment_Btn.TabIndex = 6;
            addAppointment_Btn.Text = "Submit";
            addAppointment_Btn.UseVisualStyleBackColor = false;
            addAppointment_Btn.Click += AddAppointmentBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.SystemColors.Window;
            label5.Location = new System.Drawing.Point(18, 121);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(138, 15);
            label5.TabIndex = 3;
            label5.Text = "Select Appointment Day:";
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.BackColor = System.Drawing.Color.MediumPurple;
            CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CancelBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            CancelBtn.Location = new System.Drawing.Point(341, 388);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new System.Drawing.Size(75, 32);
            CancelBtn.TabIndex = 7;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += AddCancelBtn_Click;
            // 
            // TimeZoneLabel
            // 
            TimeZoneLabel.AutoSize = true;
            TimeZoneLabel.ForeColor = System.Drawing.SystemColors.Window;
            TimeZoneLabel.Location = new System.Drawing.Point(296, 106);
            TimeZoneLabel.Name = "TimeZoneLabel";
            TimeZoneLabel.Size = new System.Drawing.Size(0, 15);
            TimeZoneLabel.TabIndex = 8;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(578, 438);
            Controls.Add(TimeZoneLabel);
            Controls.Add(CancelBtn);
            Controls.Add(addAppointment_Btn);
            Controls.Add(typeComboBox);
            Controls.Add(durationComboBox);
            Controls.Add(button1);
            Controls.Add(monthCalendar);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hoursDGV);
            Controls.Add(custNamesDGV);
            Controls.Add(addAppoinmentLabel);
            Name = "AddAppointment";
            Text = "AddAppointment";
            ((System.ComponentModel.ISupportInitialize)custNamesDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)hoursDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label addAppoinmentLabel;
        internal System.Windows.Forms.DataGridView custNamesDGV;
        internal System.Windows.Forms.DataGridView hoursDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addAppointment_Btn;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.MonthCalendar monthCalendar;
        internal System.Windows.Forms.ComboBox durationComboBox;
        internal System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label TimeZoneLabel;
    }
}