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

        public Customer? LoadCustomerFormId(int CustomerId)
        {
            Customer? FindCustomer = DataContext.Customer.Find(CustomerId);
            return FindCustomer;
        }

        public string AddCustomer(Customer Customer)
        {
            try
            {
                Customer.RegisterDate = DateTime.Now;
                DataContext.Customer.Add(Customer);
                DataContext.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateCustomer(Customer Customer)
        {
            try
            {
                DataContext.Customer.Update(Customer);
                DataContext.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string DeleteCustomer(int CustomerId)
        {
            try
            {
                Customer? FindCustomer = LoadCustomerFormId(CustomerId);
                if (FindCustomer is null) return "ไม่พบข้อมูลลูกค้า";
                FindCustomer.IsDeleted = true;
                DataContext.Customer.Update(FindCustomer);
                DataContext.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Customer> LoadAllCustomer()
        {
            try
            {
                return DataContext.Customer.Where(a => a.IsDeleted != true).ToList();
            }
            catch (Exception E)
            {
                return new List<Customer>
                {
                    new Customer
                    {
                        LicenseCode=E.Message,
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