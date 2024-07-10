using Northwind.Common.Data.Repository;


namespace Northwind.Customers.Domain.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customers.Domain.Entities.Customer, int>
    {
        List<Customers.Domain.Entities.Customer> GetCustomers();
    }
}
