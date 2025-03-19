using DesktopSchedulingApp.Forms;
using System.Linq;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Exceptions
{
    internal class CustomerExceptions
    {
        AddCustomer addCustomer;
        ModifyCustomer modifyCustomer;

        public bool AddCustomerExceptions(AddCustomer addCustomer)
        {
            this.addCustomer = addCustomer;
            // No blank customer name
            if (string.IsNullOrWhiteSpace(addCustomer.customerNameText.Text))
            {
                MessageBox.Show("ERROR: Entry can not be blank. Enter a valid customer name.");
                return EraseAndFocus(0);
            }
            // Customer name can not be a number
            if (addCustomer.customerNameText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Customer name cannot be a number.");
                return EraseAndFocus(0);
            }
            //Customer name can not contain a number
            if (addCustomer.customerNameText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: Enter letters only for customer name.");
                return EraseAndFocus(0);
            }
            // customer phone number can not be empty
            if (string.IsNullOrWhiteSpace(addCustomer.phoneText.Text))
            {
                MessageBox.Show("ERROR: Phone number cannot be empty.");
                return EraseAndFocus(1);
            }
            //customer phone number must be a number
            if (addCustomer.phoneText.Text.Any(char.IsLetter))
            {
                MessageBox.Show("ERROR: Phone number must be numbers only");
                return EraseAndFocus(1);
            }
            // customer phone number must be 7 digits long
            if (addCustomer.phoneText.Text.Trim().Length < 7 || addCustomer.phoneText.Text.Trim().Length > 8)
            {
                MessageBox.Show("ERROR: Phone number must be 7 digits long.");
                return EraseAndFocus(1);
            }
            // customer address can not be empty
            if (string.IsNullOrWhiteSpace(addCustomer.addressText.Text))
            {
                MessageBox.Show("ERROR: Address cannot be empty.");
                return EraseAndFocus(2);
            }
            //customer address can not be a number
            if (addCustomer.addressText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Address cannot be a number.");
                return EraseAndFocus(2);
            }
            // customer city can not be empty
            if (string.IsNullOrWhiteSpace(addCustomer.cityText.Text))
            {
                MessageBox.Show("ERROR: City cannot be empty.");
                return EraseAndFocus(3);
            }
            //customer city can not be a number
            if (addCustomer.cityText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot be a number.");
                return EraseAndFocus(3);
            }
            //customer city can not have a number
            if (addCustomer.cityText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot have a number in it.");
                return EraseAndFocus(3);
            }
            // customer country can not be empty
            if (string.IsNullOrWhiteSpace(addCustomer.countryComboBox.Text))
            {
                MessageBox.Show("ERROR: Country cannot be empty.");
                return EraseAndFocus(4);
            }
            //customer country can not be a number
            if (addCustomer.countryComboBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Country cannot be a number.");
                return EraseAndFocus(4);
            }
            //customer country can not have a number in it
            if (addCustomer.countryComboBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: Country cannot have a number in it.");
                return EraseAndFocus(4);
            }
            //customer country must be present in country list
            if (!ResourceInfo.Countries.Contains(addCustomer.countryComboBox.Text.Trim()))
            {
                MessageBox.Show("ERROR: The value entered is not a real country.");
                return EraseAndFocus(4);
            }
            return true;
        }

        public bool ModifyCustomerExceptions(ModifyCustomer modifyCustomer)
        {
            this.modifyCustomer = modifyCustomer;

            // No blank customer name
            if (string.IsNullOrWhiteSpace(modifyCustomer.customerNameText.Text))
            {
                MessageBox.Show("ERROR: Entry can not be blank. Enter a valid customer name.");
                return EraseAndFocus(5);
            }
            // Customer name can not be a number
            if (modifyCustomer.customerNameText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Customer name cannot be a number.");
                return EraseAndFocus(5);
            }
            //Customer name can not contain a number
            if (modifyCustomer.customerNameText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: Customer name cannot have a number in it.");
                return EraseAndFocus(5);
            }
            // customer phone number can not be empty
            if (string.IsNullOrWhiteSpace(modifyCustomer.phoneText.Text))
            {
                MessageBox.Show("ERROR: Phone number cannot be empty.");
                return EraseAndFocus(6);
            }
            //customer phone number must be a number
            if (modifyCustomer.phoneText.Text.Any(char.IsLetter))
            {
                MessageBox.Show("ERROR: Phone number must be numbers only");
                return EraseAndFocus(6);
            }
            // customer phone number must be 7 digits long
            if (modifyCustomer.phoneText.Text.Trim().Length < 7 || modifyCustomer.phoneText.Text.Trim().Length > 8)
            {
                MessageBox.Show("ERROR: Phone number must be 7 digits long.");
                return EraseAndFocus(6);
            }
            // customer address can not be empty
            if (string.IsNullOrWhiteSpace(modifyCustomer.addressText.Text))
            {
                MessageBox.Show("ERROR: Address cannot be empty.");
                return EraseAndFocus(7);
            }
            //customer address can not be a number
            if (modifyCustomer.addressText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Address cannot be a number.");
                return EraseAndFocus(7);
            }
            // customer city can not be empty
            if (string.IsNullOrWhiteSpace(modifyCustomer.cityText.Text))
            {
                MessageBox.Show("ERROR: City cannot be empty.");
                return EraseAndFocus(8);
            }
            //customer city can not be a number
            if (modifyCustomer.cityText.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot be a number.");
                return EraseAndFocus(8);
            }
            //customer city can not have a number
            if (modifyCustomer.cityText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: City cannot have a number in it.");
                return EraseAndFocus(8);
            }
            // customer country can not be empty
            if (string.IsNullOrWhiteSpace(modifyCustomer.countryComboBox.Text))
            {
                MessageBox.Show("ERROR: Country cannot be empty.");
                return EraseAndFocus(9);
            }
            //customer country can not be a number
            if (modifyCustomer.countryComboBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("ERROR: Country cannot be a number.");
                return EraseAndFocus(9);
            }
            //customer country can not have a number in it
            if (modifyCustomer.countryComboBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show("ERROR: Country cannot have a number in it.");
                return EraseAndFocus(9);
            }
            //customer country must be present in country list
            if (!ResourceInfo.Countries.Contains(modifyCustomer.countryComboBox.Text.Trim()))
            {
                MessageBox.Show("ERROR: The value entered is not a real country.");
                return EraseAndFocus(9);
            }
            return true;
        }

        private bool EraseAndFocus(int x)
        {
            switch (x)
            {
                // customer name
                case 0:
                    addCustomer.customerNameText.Text = "";
                    addCustomer.customerNameText.Focus();
                    break;
                // customer phone number
                case 1:
                    addCustomer.phoneText.Text = "";
                    addCustomer.phoneText.Focus();
                    break;
                // customer address
                case 2:
                    addCustomer.addressText.Text = "";
                    addCustomer.addressText.Focus();
                    break;
                // customer city
                case 3:
                    addCustomer.cityText.Text = "";
                    addCustomer.cityText.Focus();
                    break;
                // customer country
                case 4:
                    addCustomer.countryComboBox.Text = "";
                    addCustomer.countryComboBox.Focus();
                    break;
                // customer name
                case 5:
                    modifyCustomer.customerNameText.Text = modifyCustomer.customerInfo.Where(kv => kv.Key == "customerName").Select(kv => kv.Value).ToString();
                    modifyCustomer.customerNameText.Focus();
                    break;
                // customer phone number
                case 6:
                    modifyCustomer.phoneText.Text = modifyCustomer.customerInfo.Where(kv => kv.Key == "phone").Select(kv => kv.Value).ToString();
                    modifyCustomer.phoneText.Focus();
                    break;
                // customer address
                case 7:
                    modifyCustomer.addressText.Text = modifyCustomer.customerInfo.Where(kv => kv.Key == "address").Select(kv => kv.Value).ToString();
                    modifyCustomer.addressText.Focus();
                    break;
                // customer city
                case 8:
                    modifyCustomer.cityText.Text = modifyCustomer.customerInfo.Where(kv => kv.Key == "city").Select(kv => kv.Value).ToString();
                    modifyCustomer.cityText.Focus();
                    break;
                // customer country
                case 9:
                    modifyCustomer.countryComboBox.Text = modifyCustomer.customerInfo.Where(kv => kv.Key == "country").Select(kv => kv.Value).ToString();
                    modifyCustomer.countryComboBox.Focus();
                    break;
            }
            return false;
        }
    }
}