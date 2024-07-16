using Northwind.Customer.Application.Dto;
using Northwind.Customers.Application.Base;


namespace Northwind.Customers.Application.Contracts
{
    public interface ICustomerService
    {
        ServiceResult GetAll();
        ServiceResult GetById(string id);
        ServiceResult Add(CustomerDtoSave customer);
        ServiceResult Update(CustomerDtoUpdate customer);
        ServiceResult Remove(CustomerDtoRemove customer);
    }
}
