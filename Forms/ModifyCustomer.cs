using DesktopSchedulingApp.Models;
using DesktopSchedulingApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ModifyCustomer : Form
    {
        Customer currentCustomer;
        string currentUserName;
        public ModifyCustomer(string n, Customer c)
        {
            InitializeComponent();
            currentCustomer = c;
            currentUserName = n;
        }

        private void ModifyCustomer_Load(object sender, EventArgs e)
        {
            customerNameText.Text = currentCustomer.CustomerName;
            activeCheckBtn.Checked = currentCustomer.Active;
        }

        private void ModifyCustomerSubmitBtn_Click(object sender, EventArgs e)
        {
            //CustomerService.ModifyCustomer(currentCustomer, new Customer(
            //    currentCustomer.CustomerId,
            //    customerNameText.Text,
            //    4,
            //    activeCheckBtn.Checked
            //    )
            //);
            this.Close();
        }
    }
}
