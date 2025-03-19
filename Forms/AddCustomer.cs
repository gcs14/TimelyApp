using DesktopSchedulingApp.Exceptions;
using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void AddCustomers_Load(object sender, EventArgs e)
        {
            countryComboBox.DataSource = ResourceInfo.Countries;
            countryComboBox.Text = "";
        }

        private void AddCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            CustomerExceptions customerExceptions = new();
            if (customerExceptions.AddCustomerExceptions(this))
            {
                CustomerService.AddCustomer(this);
            }
        }

        private void AddCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
