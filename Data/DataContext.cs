using Microsoft.EntityFrameworkCore;
using SaveSyncNew.Models;

namespace SaveSyncNew.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer>? Customer { get; set; }
    }
}