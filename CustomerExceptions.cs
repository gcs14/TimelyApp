using DesktopSchedulingApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopSchedulingApp
{
    internal class CustomerExceptions
    {
        public bool AddCustomerExceptions(AddCustomers addCustomers)
        {
            if (string.IsNullOrWhiteSpace(addCustomers.customerNameText.Text))
            {
                MessageBox.Show("ERROR: Enter a valid customer name.");
                addCustomers.customerNameText.Text = "";
                addCustomers.customerNameText.Focus();
                return false;
            }
            if (int.TryParse(addCustomers.customerNameText.Text, out _))
            {
                MessageBox.Show("ERROR: Customer name cannot be a number.");
                return false;
            }
            if (addCustomers.phoneText.Text == "")
            {
                MessageBox.Show("ERROR: Phone number cannot be empty.");
                addCustomers.phoneText.Text = "";
                addCustomers.phoneText.Focus();
                return false;
            }
            if (addCustomers.phoneText.Text == "")
            {
                MessageBox.Show("ERROR: Phone number cannot be empty.");
                addCustomers.phoneText.Text = "";
                addCustomers.phoneText.Focus();
                return false;
            }
            return false;
        }

        //public bool AddPartExceptions(AddPart addPart)
        //{
        //    if (addPart.addPartName.Text == "" || addPart.addPartName is null)
        //    {
        //        MessageBox.Show("ERROR: Enter a valid part name.");
        //        addPart.addPartName.Text = "";
        //        addPart.addPartName.Focus();
        //        return false;
        //    }
        //    if (int.TryParse(addPart.addPartName.Text, out _))
        //    {
        //        MessageBox.Show("ERROR: Part name cannot be a number.");
        //        return false;
        //    }
        //    if (addPart.addPartInventory.Text == "" || !int.TryParse(addPart.addPartInventory.Text, out int inv) || inv < 0)
        //    {
        //        MessageBox.Show("ERROR: Enter a positive integer for Inventory.");
        //        addPart.addPartInventory.Text = "";
        //        addPart.addPartInventory.Focus();
        //        return false;
        //    }
        //    if (addPart.addPartPrice.Text == "" || !decimal.TryParse(addPart.addPartPrice.Text, out decimal price) || price < 0)
        //    {
        //        MessageBox.Show("ERROR: Price must be a positive decimal value.");
        //        addPart.addPartPrice.Text = "";
        //        addPart.addPartPrice.Focus();
        //        return false;
        //    }
        //    if (addPart.addPartMax.Text == "" || !int.TryParse(addPart.addPartMax.Text, out int max) || max < 0)
        //    {
        //        MessageBox.Show("ERROR: Enter a positive integer for Max.");
        //        addPart.addPartMax.Text = "";
        //        addPart.addPartMax.Focus();
        //        return false;
        //    }
        //    if (addPart.addPartMin.Text == "" || !int.TryParse(addPart.addPartMin.Text, out int min) || min < 0)
        //    {
        //        MessageBox.Show("ERROR: Enter a positive integer for Min.");
        //        addPart.addPartMin.Text = "";
        //        addPart.addPartMin.Focus();
        //        return false;
        //    }
        //    if (int.Parse(addPart.addPartMin.Text) > int.Parse(addPart.addPartMax.Text))
        //    {
        //        MessageBox.Show("ERROR: Max must be greater than Min.");
        //        return false;
        //    }
        //    if (int.Parse(addPart.addPartInventory.Text) > int.Parse(addPart.addPartMax.Text) || int.Parse(addPart.addPartInventory.Text) < int.Parse(addPart.addPartMin.Text))
        //    {
        //        MessageBox.Show("ERROR: Inventory stocked must be between Max and Min.");
        //        return false;
        //    }
        //    if (addPart.addPartFlexText.Text == "")
        //    {
        //        MessageBox.Show("ERROR: Machine ID or Company Name cannot be empty.");
        //        return false;
        //    }
        //    if (addPart.inhouseRadio.Checked == true && !int.TryParse(addPart.addPartFlexText.Text, out _))
        //    {
        //        MessageBox.Show("ERROR: Enter a valid number for Machine ID.");
        //        addPart.addPartFlexText.Text = "";
        //        return false;
        //    }
        //    if (addPart.outsourcedRadio.Checked == true && int.TryParse(addPart.addPartFlexText.Text, out _))
        //    {
        //        MessageBox.Show("ERROR: Enter a company name not a number.");
        //        addPart.addPartFlexText.Text = "";
        //        return false;
        //    }
        //    return true;
        //}
    }
}
