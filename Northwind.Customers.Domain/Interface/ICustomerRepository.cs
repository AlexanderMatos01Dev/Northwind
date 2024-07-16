using Northwind.Customers.Domain.Entities;
using System.Linq.Expressions;

namespace Northwind.Customers.Domain.Interface
{
    public interface ICustomerRepository
    {
        List<CustomerEntity> GetCustomers();
        bool Exists(Expression<Func<CustomerEntity, bool>> filter);
        List<CustomerEntity> GetAll();
        CustomerEntity GetEntityBy(string id);
        void Remove(CustomerEntity entity);
        void Save(CustomerEntity entity);
        void Update(CustomerEntity entity);
    }
}
