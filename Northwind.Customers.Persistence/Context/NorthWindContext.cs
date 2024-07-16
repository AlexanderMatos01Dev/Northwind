using Microsoft.EntityFrameworkCore;
using Northwind.Customers.Domain.Entities; // Asegúrate de que esto apunte a CustomerEntity
using System.Collections.Generic;

namespace Northwind.Customers.Persistence.Context
{
    public class NorthwindCustomerContext : DbContext
    {
        public NorthwindCustomerContext(DbContextOptions<NorthwindCustomerContext> options) : base(options)
        {
        }

        public DbSet<CustomerEntity> Customers { get; set; } // Cambiado a CustomerEntity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEntity>(entity => // Cambiado a CustomerEntity
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerId).HasMaxLength(5);
                entity.Property(c => c.CompanyName).IsRequired().HasMaxLength(40);
                entity.Property(c => c.ContactName).HasMaxLength(30);
                entity.Property(c => c.ContactTitle).HasMaxLength(30);
                entity.Property(c => c.Address).HasMaxLength(60);
                entity.Property(c => c.City).HasMaxLength(15);
                entity.Property(c => c.Region).HasMaxLength(15);
                entity.Property(c => c.PostalCode).HasMaxLength(10);
                entity.Property(c => c.Country).HasMaxLength(15);
                entity.Property(c => c.Phone).HasMaxLength(24);
                entity.Property(c => c.Fax).HasMaxLength(24);
            });
        }
    }
}
