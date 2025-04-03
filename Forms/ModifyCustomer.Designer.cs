namespace DesktopSchedulingApp.Forms
{
    partial class ModifyCustomer
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
            addCustomerLabel = new System.Windows.Forms.Label();
            customerNameLabel = new System.Windows.Forms.Label();
            customerNameText = new System.Windows.Forms.TextBox();
            phoneLabel = new System.Windows.Forms.Label();
            phoneText = new System.Windows.Forms.TextBox();
            cityLabel = new System.Windows.Forms.Label();
            cityText = new System.Windows.Forms.TextBox();
            countryLabel = new System.Windows.Forms.Label();
            countryComboBox = new System.Windows.Forms.ComboBox();
            ModifyCustomerSubmitBtn = new System.Windows.Forms.Button();
            addressText = new System.Windows.Forms.TextBox();
            addressLabel = new System.Windows.Forms.Label();
            ModifyCancelBtn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // addCustomerLabel
            // 
            addCustomerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            addCustomerLabel.Font = new System.Drawing.Font("Arial Black", 30F);
            addCustomerLabel.ForeColor = System.Drawing.Color.MediumPurple;
            addCustomerLabel.Location = new System.Drawing.Point(0, 0);
            addCustomerLabel.Name = "addCustomerLabel";
            addCustomerLabel.Size = new System.Drawing.Size(482, 101);
            addCustomerLabel.TabIndex = 1;
            addCustomerLabel.Text = "EDIT CUSTOMER";
            addCustomerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            customerNameLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            customerNameLabel.Location = new System.Drawing.Point(31, 113);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new System.Drawing.Size(62, 25);
            customerNameLabel.TabIndex = 3;
            customerNameLabel.Text = "Name";
            // 
            // customerNameText
            // 
            customerNameText.Location = new System.Drawing.Point(31, 144);
            customerNameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            customerNameText.Name = "customerNameText";
            customerNameText.Size = new System.Drawing.Size(194, 27);
            customerNameText.TabIndex = 1;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            phoneLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            phoneLabel.Location = new System.Drawing.Point(259, 113);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(140, 25);
            phoneLabel.TabIndex = 5;
            phoneLabel.Text = "Phone Number";
            // 
            // phoneText
            // 
            phoneText.Location = new System.Drawing.Point(259, 144);
            phoneText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            phoneText.Name = "phoneText";
            phoneText.Size = new System.Drawing.Size(194, 27);
            phoneText.TabIndex = 2;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cityLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            cityLabel.Location = new System.Drawing.Point(259, 205);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(44, 25);
            cityLabel.TabIndex = 7;
            cityLabel.Text = "City";
            // 
            // cityText
            // 
            cityText.Location = new System.Drawing.Point(259, 236);
            cityText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cityText.Name = "cityText";
            cityText.Size = new System.Drawing.Size(194, 27);
            cityText.TabIndex = 4;
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            countryLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            countryLabel.Location = new System.Drawing.Point(31, 288);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(79, 25);
            countryLabel.TabIndex = 11;
            countryLabel.Text = "Country";
            // 
            // countryComboBox
            // 
            countryComboBox.FormattingEnabled = true;
            countryComboBox.Location = new System.Drawing.Point(31, 319);
            countryComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            countryComboBox.Name = "countryComboBox";
            countryComboBox.Size = new System.Drawing.Size(138, 28);
            countryComboBox.TabIndex = 5;
            // 
            // ModifyCustomerSubmitBtn
            // 
            ModifyCustomerSubmitBtn.AutoSize = true;
            ModifyCustomerSubmitBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            ModifyCustomerSubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ModifyCustomerSubmitBtn.Font = new System.Drawing.Font("Arial", 11F);
            ModifyCustomerSubmitBtn.Location = new System.Drawing.Point(368, 383);
            ModifyCustomerSubmitBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ModifyCustomerSubmitBtn.Name = "ModifyCustomerSubmitBtn";
            ModifyCustomerSubmitBtn.Size = new System.Drawing.Size(86, 43);
            ModifyCustomerSubmitBtn.TabIndex = 6;
            ModifyCustomerSubmitBtn.Text = "Submit";
            ModifyCustomerSubmitBtn.UseVisualStyleBackColor = false;
            ModifyCustomerSubmitBtn.Click += ModifyCustomerSubmitBtn_Click;
            // 
            // addressText
            // 
            addressText.Location = new System.Drawing.Point(31, 236);
            addressText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            addressText.Name = "addressText";
            addressText.Size = new System.Drawing.Size(194, 27);
            addressText.TabIndex = 3;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            addressLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            addressLabel.Location = new System.Drawing.Point(31, 205);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(79, 25);
            addressLabel.TabIndex = 16;
            addressLabel.Text = "Address";
            // 
            // ModifyCancelBtn
            // 
            ModifyCancelBtn.AutoSize = true;
            ModifyCancelBtn.BackColor = System.Drawing.Color.MediumPurple;
            ModifyCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ModifyCancelBtn.Font = new System.Drawing.Font("Arial", 11F);
            ModifyCancelBtn.Location = new System.Drawing.Point(259, 383);
            ModifyCancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            ModifyCancelBtn.Name = "ModifyCancelBtn";
            ModifyCancelBtn.Size = new System.Drawing.Size(86, 43);
            ModifyCancelBtn.TabIndex = 7;
            ModifyCancelBtn.Text = "Cancel";
            ModifyCancelBtn.UseVisualStyleBackColor = false;
            ModifyCancelBtn.Click += ModifyCancelBtn_Click;
            // 
            // ModifyCustomer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(482, 452);
            Controls.Add(addressLabel);
            Controls.Add(addressText);
            Controls.Add(ModifyCancelBtn);
            Controls.Add(ModifyCustomerSubmitBtn);
            Controls.Add(countryComboBox);
            Controls.Add(countryLabel);
            Controls.Add(cityText);
            Controls.Add(cityLabel);
            Controls.Add(phoneText);
            Controls.Add(phoneLabel);
            Controls.Add(customerNameText);
            Controls.Add(customerNameLabel);
            Controls.Add(addCustomerLabel);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ModifyCustomer";
            Text = "Modify Customer";
            Load += ModifyCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label addCustomerLabel;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Button ModifyCustomerSubmitBtn;
        internal System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label addressLabel;
        internal System.Windows.Forms.TextBox customerNameText;
        internal System.Windows.Forms.TextBox phoneText;
        internal System.Windows.Forms.TextBox cityText;
        internal System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Button ModifyCancelBtn;
    }
}