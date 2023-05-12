using SaveSyncNew.Data;
using SaveSyncNew.Models;

namespace SaveSyncNew.Services
{
    public class CustomerService
    {
        public void AddCustomer(Customer Customer)
        {
            CustomerContext context = new();
            context.Customer.Add(Customer);
        }
    }
}