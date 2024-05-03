using AutoMapperApı.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperApı.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options)
        {





        }
        public DbSet<Customer> Customers { get; set; }
    }
}
