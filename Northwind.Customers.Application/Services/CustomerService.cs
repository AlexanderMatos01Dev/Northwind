using Microsoft.Extensions.Logging;
using Northwind.Customers.Domain.Interface;
using Northwind.Customers.Domain.Entities; // Asegúrate de que esto apunte a CustomerEntity
using Northwind.Customers.Application.Contracts;
using Northwind.Customers.Application.Base;
using Northwind.Customer.Application.Dto;
using Northwind.Customers.Application.Extensions;

namespace Northwind.Customers.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            this.customerRepository = customerRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var customers = this.customerRepository.GetAll();

                result.Result = (from customer in customers
                                 select new CustomerDtoGetAll()
                                 {
                                     CustomerId = customer.CustomerId, // Cambiado a CustomerId
                                     CompanyName = customer.CompanyName,
                                     ContactName = customer.ContactName,
                                     ContactTitle = customer.ContactTitle,
                                     Address = customer.Address,
                                     City = customer.City,
                                     Region = customer.Region,
                                     PostalCode = customer.PostalCode,
                                     Country = customer.Country,
                                     Phone = customer.Phone,
                                     Fax = customer.Fax
                                 }).ToList();

                result.Success = true;
                result.Message = "Clientes obtenidos exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los clientes.";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServiceResult GetById(string id) // Cambiado a string
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var customer = this.customerRepository.GetEntityBy(id); // Asegúrate de que el repositorio acepte un string

                if (customer == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró el cliente con ID: {id}.";
                }
                else
                {
                    result.Result = new CustomerDtoGetAll()
                    {
                        CustomerId = customer.CustomerId, // Cambiado a CustomerId
                        CompanyName = customer.CompanyName,
                        ContactName = customer.ContactName,
                        ContactTitle = customer.ContactTitle,
                        Address = customer.Address,
                        City = customer.City,
                        Region = customer.Region,
                        PostalCode = customer.PostalCode,
                        Country = customer.Country,
                        Phone = customer.Phone,
                        Fax = customer.Fax
                    };
                    result.Success = true;
                    result.Message = "Cliente obtenido exitosamente.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el cliente.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Add(CustomerDtoSave customerDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = customerDtoSave.IsValidCustomer();

                if (!result.Success)
                    return result;

                var customer = new CustomerEntity() // Cambiado a CustomerEntity
                {
                    CustomerId = customerDtoSave.CustomerId,
                    CompanyName = customerDtoSave.CompanyName,
                    ContactName = customerDtoSave.ContactName,
                    ContactTitle = customerDtoSave.ContactTitle,
                    Address = customerDtoSave.Address,
                    City = customerDtoSave.City,
                    Region = customerDtoSave.Region,
                    PostalCode = customerDtoSave.PostalCode,
                    Country = customerDtoSave.Country,
                    Phone = customerDtoSave.Phone,
                    Fax = customerDtoSave.Fax
                };

                this.customerRepository.Save(customer);
                result.Success = true;
                result.Message = "Cliente añadido exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el cliente.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Update(CustomerDtoUpdate customerDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = customerDtoUpdate.IsValidCustomer();

                if (!result.Success)
                    return result;

                var customer = new CustomerEntity() // Cambiado a CustomerEntity
                {
                    CustomerId = customerDtoUpdate.CustomerId,
                    CompanyName = customerDtoUpdate.CompanyName,
                    ContactName = customerDtoUpdate.ContactName,
                    ContactTitle = customerDtoUpdate.ContactTitle,
                    Address = customerDtoUpdate.Address,
                    City = customerDtoUpdate.City,
                    Region = customerDtoUpdate.Region,
                    PostalCode = customerDtoUpdate.PostalCode,
                    Country = customerDtoUpdate.Country,
                    Phone = customerDtoUpdate.Phone,
                    Fax = customerDtoUpdate.Fax
                };

                this.customerRepository.Update(customer);
                result.Success = true;
                result.Message = "Cliente actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el cliente.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Remove(CustomerDtoRemove customerDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (customerDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(customerDtoRemove)} es requerido.";
                    return result;
                }

                var customer = new CustomerEntity() // Cambiado a CustomerEntity
                {
                    CustomerId = customerDtoRemove.CustomerId
                };

                this.customerRepository.Remove(customer);
                result.Success = true;
                result.Message = "Cliente eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el cliente.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }
    }
}
