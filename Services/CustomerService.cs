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
                DataContext.Customer!.Add(Customer);
                var a = DataContext.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}