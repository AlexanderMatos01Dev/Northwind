using Microsoft.EntityFrameworkCore;
using Northwind.Customers.Domain.Interface;
using Northwind.Customers.Domain.Entities; // Asegúrate de que esto apunte a CustomerEntity
using Northwind.Customers.Persistence.Context;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace Northwind.Customers.Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindCustomerContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(NorthwindCustomerContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<CustomerEntity> GetCustomers() // Implementación del método GetCustomers
        {
            return _context.Customers.ToList();
        }

        public bool Exists(Expression<Func<CustomerEntity, bool>> filter)
        {
            return _context.Customers.Any(filter);
        }

        public List<CustomerEntity> GetAll()
        {
            return _context.Customers.ToList();
        }

        public CustomerEntity GetEntityBy(string id)
        {
            try
            {
                var customer = _context.Customers.Find(id);

                if (customer == null)
                    throw new InvalidOperationException("Customer not found.");

                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error obtaining the customer.", ex);
                throw;
            }
        }

        public void Remove(CustomerEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity customer cannot be null.");

                var customerToRemove = _context.Customers.Find(entity.CustomerId);

                if (customerToRemove == null)
                    throw new InvalidOperationException("The customer you want to delete is not found.");

                _context.Customers.Remove(customerToRemove);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Concurrency conflict: The entity was modified or deleted by another process.", ex);
                throw new InvalidOperationException("Concurrency conflict: The entity was modified or deleted by another process.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error removing the customer.", ex);
                throw;
            }
        }

        public void Save(CustomerEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity customer cannot be null.");

                if (Exists(c => c.CustomerId == entity.CustomerId))
                    throw new InvalidOperationException("The customer is already registered.");

                _context.Customers.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError("Error adding the customer: {0}", dbEx.InnerException?.Message ?? dbEx.Message);
                if (dbEx.InnerException != null)
                {
                    _logger.LogError("Inner exception: {0}", dbEx.InnerException.ToString());
                }
                throw new InvalidOperationException("An error occurred while saving the customer. See the inner exception for details.", dbEx);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error adding the customer.", ex);
                throw;
            }
        }

        public void Update(CustomerEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentException("The entity customer cannot be null.");

                var customerToUpdate = _context.Customers.Find(entity.CustomerId);

                if (customerToUpdate == null)
                    throw new InvalidOperationException("The customer you want to update is not found.");

                customerToUpdate.CompanyName = entity.CompanyName;
                customerToUpdate.ContactName = entity.ContactName;
                customerToUpdate.ContactTitle = entity.ContactTitle;
                customerToUpdate.Address = entity.Address;
                customerToUpdate.City = entity.City;
                customerToUpdate.Region = entity.Region;
                customerToUpdate.PostalCode = entity.PostalCode;
                customerToUpdate.Country = entity.Country;
                customerToUpdate.Phone = entity.Phone;
                customerToUpdate.Fax = entity.Fax;

                _context.Entry(customerToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating the customer.", ex);
                throw;
            }
        }
    }
}
