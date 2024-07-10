using Microsoft.EntityFrameworkCore;
using Northwind.Customers.Domain.Entities;


namespace Northwind.Customers.Persistence.Context
{
    internal class NorthWindContext : DbContext
    {
        #region "Constructor"
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Customer> Categories { get; set; }
        public DbSet<Domain.Entities.Customer> Customers { get; set; }
        #endregion
    }
}
