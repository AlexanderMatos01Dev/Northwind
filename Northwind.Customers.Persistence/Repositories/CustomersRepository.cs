

using Northwind.Customers.Domain.Interfaces;
using System.Linq.Expressions;

namespace Northwind.Customers.Persistence.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Customer GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void remove(Domain.Entities.Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Customer entity)
        {
            throw new NotImplementedException();
        }

        public void update(Domain.Entities.Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
