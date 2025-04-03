using DesktopSchedulingApp.Service;
using System;
using System.Windows.Forms;

namespace DesktopSchedulingApp.Forms
{
    public partial class ViewCustomers : Form
    {
        int selectedCustomerId;

        public ViewCustomers()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            PopulateCustomerTable();
        }

        private void PopulateCustomerTable()
        {
            CustomerService.LoadCustomerData(this);
            dataGridView1.CurrentCell = null;
        }

        private void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            new AddCustomer().ShowDialog();
            PopulateCustomerTable();
        }

        private void ModifyCustomerBtn_Click(object sender, EventArgs e)
        {
            new ModifyCustomer(selectedCustomerId).ShowDialog();
            PopulateCustomerTable();
        }

        private void DeleteCustomerBtn_Click(object sender, EventArgs e)
        {
            CustomerService.DeleteCustomer(selectedCustomerId);
            PopulateCustomerTable();
        }

        private void CustomerSelection(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedCustomerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
