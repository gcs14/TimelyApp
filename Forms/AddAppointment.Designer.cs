namespace DesktopSchedulingApp.Forms
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
            comboBox1 = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(21, 98);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(699, 663);
            Controls.Add(comboBox1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "AddAppointment";
            Text = "AddAppointment";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
    }
}