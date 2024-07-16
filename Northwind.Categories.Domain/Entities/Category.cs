using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Categories.Domain.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryID { get; set; }

        [Required]
        [Column("CategoryName")]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("Picture")]
        public byte[]? Picture { get; set; }
    }
}
