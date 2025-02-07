namespace DesktopSchedulingApp.Forms
{
    partial class ViewCustomers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            addCustomerBtn = new System.Windows.Forms.Button();
            modifyCustomerBtn = new System.Windows.Forms.Button();
            deleteCustomerBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new System.Drawing.Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new System.Drawing.Size(776, 305);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += CustomerSelection;
            // 
            // addCustomerBtn
            // 
            addCustomerBtn.AutoSize = true;
            addCustomerBtn.BackColor = System.Drawing.Color.MediumPurple;
            addCustomerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            addCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            addCustomerBtn.Location = new System.Drawing.Point(190, 356);
            addCustomerBtn.Name = "addCustomerBtn";
            addCustomerBtn.Size = new System.Drawing.Size(75, 32);
            addCustomerBtn.TabIndex = 1;
            addCustomerBtn.Text = "Add";
            addCustomerBtn.UseVisualStyleBackColor = false;
            addCustomerBtn.Click += AddCustomerBtn_Click;
            // 
            // modifyCustomerBtn
            // 
            modifyCustomerBtn.AutoSize = true;
            modifyCustomerBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            modifyCustomerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            modifyCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            modifyCustomerBtn.Location = new System.Drawing.Point(359, 356);
            modifyCustomerBtn.Name = "modifyCustomerBtn";
            modifyCustomerBtn.Size = new System.Drawing.Size(75, 32);
            modifyCustomerBtn.TabIndex = 1;
            modifyCustomerBtn.Text = "Modify";
            modifyCustomerBtn.UseVisualStyleBackColor = false;
            modifyCustomerBtn.Click += ModifyCustomerBtn_Click;
            // 
            // deleteCustomerBtn
            // 
            deleteCustomerBtn.AutoSize = true;
            deleteCustomerBtn.BackColor = System.Drawing.Color.Silver;
            deleteCustomerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            deleteCustomerBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            deleteCustomerBtn.Location = new System.Drawing.Point(533, 356);
            deleteCustomerBtn.Name = "deleteCustomerBtn";
            deleteCustomerBtn.Size = new System.Drawing.Size(75, 32);
            deleteCustomerBtn.TabIndex = 1;
            deleteCustomerBtn.Text = "Delete";
            deleteCustomerBtn.UseVisualStyleBackColor = false;
            deleteCustomerBtn.Click += DeleteCustomerBtn_Click;
            // 
            // ViewCustomers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(deleteCustomerBtn);
            Controls.Add(modifyCustomerBtn);
            Controls.Add(addCustomerBtn);
            Controls.Add(dataGridView1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "ViewCustomers";
            Text = "ViewCustomers";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button addCustomerBtn;
        private System.Windows.Forms.Button modifyCustomerBtn;
        private System.Windows.Forms.Button deleteCustomerBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}