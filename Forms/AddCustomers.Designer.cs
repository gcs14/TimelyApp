namespace DesktopSchedulingApp.Forms
{
    partial class AddCustomers
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
            customerNameText = new System.Windows.Forms.TextBox();
            addCustomerSubmitBtn = new System.Windows.Forms.Button();
            customerNameLabel = new System.Windows.Forms.Label();
            phoneText = new System.Windows.Forms.TextBox();
            phoneLabel = new System.Windows.Forms.Label();
            countryLabel = new System.Windows.Forms.Label();
            cityText = new System.Windows.Forms.TextBox();
            cityLabel = new System.Windows.Forms.Label();
            postalText = new System.Windows.Forms.TextBox();
            postalLabel = new System.Windows.Forms.Label();
            countryComboBox = new System.Windows.Forms.ComboBox();
            activeCheckBtn = new System.Windows.Forms.CheckBox();
            addCustomerLabel = new System.Windows.Forms.Label();
            addressText = new System.Windows.Forms.TextBox();
            addressLabel = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // customerNameText
            // 
            customerNameText.Location = new System.Drawing.Point(27, 108);
            customerNameText.Name = "customerNameText";
            customerNameText.Size = new System.Drawing.Size(170, 23);
            customerNameText.TabIndex = 1;
            // 
            // addCustomerSubmitBtn
            // 
            addCustomerSubmitBtn.AutoSize = true;
            addCustomerSubmitBtn.BackColor = System.Drawing.Color.Silver;
            addCustomerSubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            addCustomerSubmitBtn.Font = new System.Drawing.Font("Arial", 11F);
            addCustomerSubmitBtn.Location = new System.Drawing.Point(165, 347);
            addCustomerSubmitBtn.Name = "addCustomerSubmitBtn";
            addCustomerSubmitBtn.Size = new System.Drawing.Size(75, 32);
            addCustomerSubmitBtn.TabIndex = 1;
            addCustomerSubmitBtn.Text = "Submit";
            addCustomerSubmitBtn.UseVisualStyleBackColor = false;
            addCustomerSubmitBtn.Click += AddCustomerSubmitBtn_Click;
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            customerNameLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            customerNameLabel.Location = new System.Drawing.Point(27, 85);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new System.Drawing.Size(49, 20);
            customerNameLabel.TabIndex = 2;
            customerNameLabel.Text = "Name";
            // 
            // phoneText
            // 
            phoneText.Location = new System.Drawing.Point(27, 170);
            phoneText.Name = "phoneText";
            phoneText.Size = new System.Drawing.Size(170, 23);
            phoneText.TabIndex = 2;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            phoneLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            phoneLabel.Location = new System.Drawing.Point(27, 147);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(108, 20);
            phoneLabel.TabIndex = 2;
            phoneLabel.Text = "Phone Number";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            countryLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            countryLabel.Location = new System.Drawing.Point(27, 275);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new System.Drawing.Size(60, 20);
            countryLabel.TabIndex = 2;
            countryLabel.Text = "Country";
            // 
            // cityText
            // 
            cityText.Location = new System.Drawing.Point(27, 235);
            cityText.Name = "cityText";
            cityText.Size = new System.Drawing.Size(170, 23);
            cityText.TabIndex = 3;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cityLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            cityLabel.Location = new System.Drawing.Point(27, 212);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(34, 20);
            cityLabel.TabIndex = 2;
            cityLabel.Text = "City";
            // 
            // postalText
            // 
            postalText.Location = new System.Drawing.Point(227, 235);
            postalText.Name = "postalText";
            postalText.Size = new System.Drawing.Size(170, 23);
            postalText.TabIndex = 0;
            // 
            // postalLabel
            // 
            postalLabel.AutoSize = true;
            postalLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            postalLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            postalLabel.Location = new System.Drawing.Point(227, 212);
            postalLabel.Name = "postalLabel";
            postalLabel.Size = new System.Drawing.Size(87, 20);
            postalLabel.TabIndex = 2;
            postalLabel.Text = "Postal Code";
            // 
            // countryComboBox
            // 
            countryComboBox.FormattingEnabled = true;
            countryComboBox.Items.AddRange(new object[] { "USA", "Canada", "Norway", "Mexico" });
            countryComboBox.Location = new System.Drawing.Point(27, 298);
            countryComboBox.Name = "countryComboBox";
            countryComboBox.Size = new System.Drawing.Size(121, 23);
            countryComboBox.TabIndex = 3;
            // 
            // activeCheckBtn
            // 
            activeCheckBtn.AutoSize = true;
            activeCheckBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            activeCheckBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            activeCheckBtn.Location = new System.Drawing.Point(227, 296);
            activeCheckBtn.Name = "activeCheckBtn";
            activeCheckBtn.Size = new System.Drawing.Size(69, 24);
            activeCheckBtn.TabIndex = 4;
            activeCheckBtn.Text = "Active";
            activeCheckBtn.UseVisualStyleBackColor = true;
            // 
            // addCustomerLabel
            // 
            addCustomerLabel.AutoSize = true;
            addCustomerLabel.Font = new System.Drawing.Font("Arial Black", 30F);
            addCustomerLabel.ForeColor = System.Drawing.Color.MediumPurple;
            addCustomerLabel.Location = new System.Drawing.Point(15, 9);
            addCustomerLabel.Name = "addCustomerLabel";
            addCustomerLabel.Size = new System.Drawing.Size(391, 56);
            addCustomerLabel.TabIndex = 0;
            addCustomerLabel.Text = "NEW CUSTOMER";
            // 
            // addressText
            // 
            addressText.Location = new System.Drawing.Point(227, 170);
            addressText.Name = "addressText";
            addressText.Size = new System.Drawing.Size(170, 23);
            addressText.TabIndex = 3;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            addressLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            addressLabel.Location = new System.Drawing.Point(227, 147);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(62, 20);
            addressLabel.TabIndex = 2;
            addressLabel.Text = "Address";
            // 
            // AddCustomers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(418, 412);
            Controls.Add(addCustomerLabel);
            Controls.Add(activeCheckBtn);
            Controls.Add(countryComboBox);
            Controls.Add(postalLabel);
            Controls.Add(addressLabel);
            Controls.Add(cityLabel);
            Controls.Add(countryLabel);
            Controls.Add(phoneLabel);
            Controls.Add(customerNameLabel);
            Controls.Add(addCustomerSubmitBtn);
            Controls.Add(postalText);
            Controls.Add(addressText);
            Controls.Add(cityText);
            Controls.Add(phoneText);
            Controls.Add(customerNameText);
            Name = "AddCustomers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox customerNameText;
        private System.Windows.Forms.Button addCustomerSubmitBtn;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.TextBox phoneText;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox cityText;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox postalText;
        private System.Windows.Forms.Label postalLabel;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.CheckBox activeCheckBtn;
        private System.Windows.Forms.Label addCustomerLabel;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label addressLabel;
    }
}