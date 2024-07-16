using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Customers.Domain.Entities
{
    [Table("Customers")]
    public class CustomerEntity
    {
        [Key]
        [Column("CustomerID")]
        [MaxLength(5)]
        public string CustomerId { get; set; }

        [Required]
        [Column("CompanyName")]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [Column("ContactName")]
        [MaxLength(30)]
        public string? ContactName { get; set; }

        [Column("ContactTitle")]
        [MaxLength(30)]
        public string? ContactTitle { get; set; }

        [Column("Address")]
        [MaxLength(60)]
        public string? Address { get; set; }

        [Column("City")]
        [MaxLength(15)]
        public string? City { get; set; }

        [Column("Region")]
        [MaxLength(15)]
        public string? Region { get; set; }

        [Column("PostalCode")]
        [MaxLength(10)]
        public string? PostalCode { get; set; }

        [Column("Country")]
        [MaxLength(15)]
        public string? Country { get; set; }

        [Column("Phone")]
        [MaxLength(24)]
        public string? Phone { get; set; }

        [Column("Fax")]
        [MaxLength(24)]
        public string? Fax { get; set; }
    }
}
