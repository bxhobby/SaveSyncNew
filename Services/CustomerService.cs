using SaveSyncNew.Data;
using SaveSyncNew.Models;

namespace SaveSyncNew.Services
{
    public class CustomerService
    {
        private readonly DataContext DataContext;
        public CustomerService(DataContext a)
        {
            DataContext = a;
        }

        public string AddCustomer(Customer Customer)
        {
            try
            {
                Customer.RegisterDate = DateTime.Now;
                DataContext.Customer.Add(Customer);
                var a = DataContext.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void DeleteCustomer(int CustomerId)
        {
            Customer? FindCustomer = DataContext.Customer.Find(CustomerId);
            try
            {
                if (FindCustomer is not null)
                {
                    DataContext.Customer.Remove(FindCustomer);
                    DataContext.SaveChanges();
                }
            }
            catch { }
        }

        public List<Customer>? LoadAllCustomer()
        {
            try
            {
                return DataContext.Customer.ToList();
            }
            catch
            {
                return new List<Customer>
                {
                    new Customer
                    {
                        LicenseCode="NULL",
                        ShopCode="NULL",
                        ShopName="NULL",
                        CustomerName="NULL",
                        Province="NULL",
                        Phone="NULL",
                    }
                };
            }

        }
    }
}