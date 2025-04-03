namespace DesktopSchedulingApp.Forms
{
    partial class ModifyAppointment
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
            monthCalendar = new System.Windows.Forms.MonthCalendar();
            label5 = new System.Windows.Forms.Label();
            durationComboBox = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            hoursDGV = new System.Windows.Forms.DataGridView();
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            custNamesDGV = new System.Windows.Forms.DataGridView();
            typeComboBox = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            ModifyAppointment_Btn = new System.Windows.Forms.Button();
            CancelBtn = new System.Windows.Forms.Button();
            TimeZoneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)hoursDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)custNamesDGV).BeginInit();
            SuspendLayout();
            // 
            // addAppoinmentLabel
            // 
            addAppoinmentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            addAppoinmentLabel.Font = new System.Drawing.Font("Arial Black", 31F);
            addAppoinmentLabel.ForeColor = System.Drawing.Color.MediumPurple;
            addAppoinmentLabel.Location = new System.Drawing.Point(0, 0);
            addAppoinmentLabel.Name = "addAppoinmentLabel";
            addAppoinmentLabel.Size = new System.Drawing.Size(661, 115);
            addAppoinmentLabel.TabIndex = 2;
            addAppoinmentLabel.Text = "EDIT APPOINTMENT";
            addAppoinmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monthCalendar
            // 
            monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            monthCalendar.Location = new System.Drawing.Point(21, 193);
            monthCalendar.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 1;
            monthCalendar.DateChanged += MonthCalendar1_DateSelected;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.SystemColors.Window;
            label5.Location = new System.Drawing.Point(21, 161);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(174, 20);
            label5.TabIndex = 6;
            label5.Text = "Select Appointment Day:";
            // 
            // durationComboBox
            // 
            durationComboBox.FormattingEnabled = true;
            durationComboBox.Items.AddRange(new object[] { "30 Mins", "60 Mins" });
            durationComboBox.Location = new System.Drawing.Point(337, 415);
            durationComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            durationComboBox.Name = "durationComboBox";
            durationComboBox.Size = new System.Drawing.Size(138, 28);
            durationComboBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.Window;
            label2.Location = new System.Drawing.Point(338, 161);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(119, 20);
            label2.TabIndex = 8;
            label2.Text = "Select Time Slot:";
            // 
            // hoursDGV
            // 
            hoursDGV.AllowUserToAddRows = false;
            hoursDGV.AllowUserToDeleteRows = false;
            hoursDGV.AllowUserToResizeColumns = false;
            hoursDGV.AllowUserToResizeRows = false;
            hoursDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            hoursDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            hoursDGV.Location = new System.Drawing.Point(338, 195);
            hoursDGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            hoursDGV.MultiSelect = false;
            hoursDGV.Name = "hoursDGV";
            hoursDGV.ReadOnly = true;
            hoursDGV.RowHeadersVisible = false;
            hoursDGV.RowHeadersWidth = 51;
            hoursDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            hoursDGV.Size = new System.Drawing.Size(137, 216);
            hoursDGV.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(501, 415);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(137, 31);
            button1.TabIndex = 12;
            button1.Text = "New Customer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewCustomer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.SystemColors.Window;
            label1.Location = new System.Drawing.Point(501, 161);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(119, 20);
            label1.TabIndex = 11;
            label1.Text = "Select Customer:";
            // 
            // custNamesDGV
            // 
            custNamesDGV.AllowUserToAddRows = false;
            custNamesDGV.AllowUserToDeleteRows = false;
            custNamesDGV.AllowUserToResizeColumns = false;
            custNamesDGV.AllowUserToResizeRows = false;
            custNamesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            custNamesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            custNamesDGV.Location = new System.Drawing.Point(501, 195);
            custNamesDGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            custNamesDGV.MultiSelect = false;
            custNamesDGV.Name = "custNamesDGV";
            custNamesDGV.ReadOnly = true;
            custNamesDGV.RowHeadersVisible = false;
            custNamesDGV.RowHeadersWidth = 51;
            custNamesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            custNamesDGV.Size = new System.Drawing.Size(137, 216);
            custNamesDGV.TabIndex = 4;
            // 
            // typeComboBox
            // 
            typeComboBox.FormattingEnabled = true;
            typeComboBox.Items.AddRange(new object[] { "Presentation", "Scrum", "Consulation", "Other" });
            typeComboBox.Location = new System.Drawing.Point(21, 449);
            typeComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            typeComboBox.Name = "typeComboBox";
            typeComboBox.Size = new System.Drawing.Size(138, 28);
            typeComboBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = System.Drawing.SystemColors.Window;
            label4.Location = new System.Drawing.Point(21, 425);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 20);
            label4.TabIndex = 13;
            label4.Text = "Type:";
            // 
            // ModifyAppointment_Btn
            // 
            ModifyAppointment_Btn.AutoSize = true;
            ModifyAppointment_Btn.BackColor = System.Drawing.Color.DarkSeaGreen;
            ModifyAppointment_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ModifyAppointment_Btn.Font = new System.Drawing.Font("Arial", 11F);
            ModifyAppointment_Btn.Location = new System.Drawing.Point(525, 517);
            ModifyAppointment_Btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ModifyAppointment_Btn.Name = "ModifyAppointment_Btn";
            ModifyAppointment_Btn.Size = new System.Drawing.Size(86, 43);
            ModifyAppointment_Btn.TabIndex = 6;
            ModifyAppointment_Btn.Text = "Submit";
            ModifyAppointment_Btn.UseVisualStyleBackColor = false;
            ModifyAppointment_Btn.Click += ModifyAppointmentBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.AutoSize = true;
            CancelBtn.BackColor = System.Drawing.Color.MediumPurple;
            CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            CancelBtn.Font = new System.Drawing.Font("Arial", 11F);
            CancelBtn.Location = new System.Drawing.Point(390, 517);
            CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new System.Drawing.Size(86, 43);
            CancelBtn.TabIndex = 7;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += ModifyCancelBtn_Click;
            // 
            // TimeZoneLabel
            // 
            TimeZoneLabel.AutoSize = true;
            TimeZoneLabel.ForeColor = System.Drawing.SystemColors.Window;
            TimeZoneLabel.Location = new System.Drawing.Point(337, 141);
            TimeZoneLabel.Name = "TimeZoneLabel";
            TimeZoneLabel.Size = new System.Drawing.Size(0, 20);
            TimeZoneLabel.TabIndex = 14;
            // 
            // ModifyAppointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(661, 584);
            Controls.Add(TimeZoneLabel);
            Controls.Add(CancelBtn);
            Controls.Add(ModifyAppointment_Btn);
            Controls.Add(typeComboBox);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(custNamesDGV);
            Controls.Add(durationComboBox);
            Controls.Add(label2);
            Controls.Add(hoursDGV);
            Controls.Add(label5);
            Controls.Add(monthCalendar);
            Controls.Add(addAppoinmentLabel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ModifyAppointment";
            Text = "ModifyAppointment";
            Load += ModifyAppointment_Load;
            ((System.ComponentModel.ISupportInitialize)hoursDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)custNamesDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label addAppoinmentLabel;
        internal System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox durationComboBox;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.DataGridView hoursDGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView custNamesDGV;
        internal System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ModifyAppointment_Btn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label TimeZoneLabel;
    }
}