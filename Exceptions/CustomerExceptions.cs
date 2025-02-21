using DesktopSchedulingApp.Forms;
using DesktopSchedulingApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Exceptions
{
    internal class CustomerExceptions
    {
        AddCustomers addCustomers;
        public bool AddCustomerExceptions(AddCustomers addCustomers)
        {
            this.addCustomers = addCustomers;
            // No blank customer name
            if (string.IsNullOrWhiteSpace(addCustomers.customerNameText.Text))
            {
                MessageBox.Show("ERROR: Enter a valid customer name.");
                return EraseAndFocus(0);
            }
            // Customer name can not be a number
            //if (int.TryParse(addCustomers.customerNameText.Text, out _))
            if (addCustomers.customerNameText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Customer name cannot be a number.");
                return EraseAndFocus(0);
            }
            //Customer name can not contain a number
            if (addCustomers.customerNameText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: Enter letters only for customer name.");
                return EraseAndFocus(0);
            }
            // customer phone number can not be empty
            if (addCustomers.phoneText.Text == "")
            {
                MessageBox.Show("ERROR: Phone number cannot be empty.");
                return EraseAndFocus(1);
            }
            //customer phone number must be a number
            if (!addCustomers.phoneText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Enter numbers only for phone number.");
                return EraseAndFocus(1);
            }
            // customer phone number must be 7 digits long
            if (addCustomers.phoneText.Text.Length != 7)
            {
                MessageBox.Show("ERROR: Phone number must be 7 digits long.");
                return EraseAndFocus(1);
            }
            // customer address can not be empty
            if (addCustomers.addressText.Text == "")
            {
                MessageBox.Show("ERROR: Address cannot be empty.");
                return EraseAndFocus(2);
            }
            //customer address can not be a number
            if (addCustomers.addressText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Address cannot be a number.");
                return EraseAndFocus(2);
            }
            // customer city can not be empty
            if (addCustomers.cityText.Text == "")
            {
                MessageBox.Show("ERROR: City cannot be empty.");
                return EraseAndFocus(3);
            }
            //customer city can not be a number
            if (addCustomers.cityText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot be a number.");
                return EraseAndFocus(3);
            }
            //customer city can not have a number
            if (addCustomers.cityText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot have a number in it.");
                return EraseAndFocus(3);
            }
            //customer city can not have a number in it
            if (addCustomers.cityText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot have a number in it.");
                return EraseAndFocus(3);
            }
            // customer country can not be empty
            if (addCustomers.countryComboBox.Text == "")
            {
                MessageBox.Show("ERROR: Country cannot be empty.");
                return EraseAndFocus(4);
            }
            //customer country can not be a number
            if (addCustomers.countryComboBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Country cannot be a number.");
                return EraseAndFocus(4);
            }
            //customer country can not have a number in it
            if (addCustomers.countryComboBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: Country cannot have a number in it.");
                return EraseAndFocus(4);
            }
            //customer country must be present in country list
            if (!ResourceInfo.Countries.Contains(addCustomers.countryComboBox.Text.Trim()))
            {
                MessageBox.Show("ERROR: The value entered is not a real country.");
                return EraseAndFocus(4);
            }
            return true;
        }

        private bool EraseAndFocus(int x)
        {
            switch (x)
            {
                // customer name
                case 0:
                    addCustomers.customerNameText.Text = "";
                    addCustomers.customerNameText.Focus();
                    break;
                // customer phone number
                case 1:
                    addCustomers.phoneText.Text = "";
                    addCustomers.phoneText.Focus();
                    break;
                // customer address
                case 2:
                    addCustomers.addressText.Text = "";
                    addCustomers.addressText.Focus();
                    break;
                // customer city
                case 3:
                    addCustomers.cityText.Text = "";
                    addCustomers.cityText.Focus();
                    break;
                // customer country
                case 4:
                    addCustomers.countryComboBox.Text = "";
                    addCustomers.countryComboBox.Focus();
                    break;
            }
            return false;
        }
    }
}
