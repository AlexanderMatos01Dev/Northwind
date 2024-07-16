using Microsoft.Extensions.DependencyInjection;
using Northwind.Customers.Application.Contracts;
using Northwind.Customers.Domain.Interface;
using Northwind.Customers.Persistence.Repository;
using Northwind.Customers.Service;

namespace Northwind.Customers.IOC.Dependency
{
    public static class CustomerDependency
    {
        public static void AddCustomerDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            #endregion

            #region "Servicios"
            services.AddTransient<ICustomerService, CustomerService>();
            #endregion
        }
    }
}
