using Northwind.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Customers.Domain.Entities
{
    public abstract class Customer : BaseEntity<string>
    {

        [Column("CustomerID")]
        override public string Id { get; set; }
    }
}
