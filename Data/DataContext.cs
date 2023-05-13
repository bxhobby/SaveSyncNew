using Microsoft.EntityFrameworkCore;
using SaveSyncNew.Models;

namespace SaveSyncNew.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Customer> Customer { get; set; }
    }
}