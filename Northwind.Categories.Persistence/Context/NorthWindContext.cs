using Microsoft.EntityFrameworkCore;
using Northwind.Categories.Domain.Entities;

namespace Northwind.Categories.Persistence.Context
{
    internal class NorthWindContext : DbContext
    {
        #region "Constructor"
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Entities.Category> Customers { get; set; }

        #endregion
    }
}
