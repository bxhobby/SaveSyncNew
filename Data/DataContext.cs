using Microsoft.EntityFrameworkCore;
using SaveSyncNew.Models;

namespace SaveSyncNew.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch
            {
            }
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Shop> Shop { get; set; }
    }
}