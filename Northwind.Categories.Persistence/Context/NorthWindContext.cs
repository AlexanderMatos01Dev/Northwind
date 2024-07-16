using Microsoft.EntityFrameworkCore;
using Northwind.Categories.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Northwind.Categories.Persistence.Context
{
    public class NorthwindContext : DbContext
    {
        #region "Constructor"

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
        }
        #endregion

        #region "Db Sets"
        public DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryID);
                entity.Property(c => c.CategoryID).HasColumnName("CategoryID");
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(15);
                entity.Property(c => c.Description).HasColumnType("ntext");
                entity.Property(c => c.Picture).HasColumnType("image");
            });
        }
    }
}
