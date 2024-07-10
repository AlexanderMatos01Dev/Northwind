using Northwind.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Categories.Domain.Entities
{
    public abstract class Category : BaseEntity<int>
    {
        [Column("CategoryID")]
       override public int Id { get; set; }
        
    }
}
