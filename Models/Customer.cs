namespace DesktopSchedulingApp.Models
{
    public class Customer : Address
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public Customer (int customerId, string customerName, int addressId)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            AddressId = addressId;
        }
    }
}
