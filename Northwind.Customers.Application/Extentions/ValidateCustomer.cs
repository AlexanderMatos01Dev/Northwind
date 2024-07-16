using Northwind.Customer.Application.Dto;
using Northwind.Customers.Application.Base;

namespace Northwind.Customers.Application.Extensions
{
    public static class ValidateCustomer
    {
        public static ServiceResult IsValidCustomer(this CustomerDtoBase baseCustomer)
        {
            ServiceResult result = new ServiceResult();

            if (baseCustomer is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseCustomer)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseCustomer?.CompanyName))
            {
                result.Success = false;
                result.Message = "El nombre de la compañía es requerido.";
                return result;
            }

            if (baseCustomer.CompanyName.Length > 40)
            {
                result.Success = false;
                result.Message = "El nombre de la compañía no puede exceder los 40 caracteres.";
                return result;
            }

            if (!string.IsNullOrEmpty(baseCustomer?.ContactName) && baseCustomer.ContactName.Length > 30)
            {
                result.Success = false;
                result.Message = "El nombre del contacto no puede exceder los 30 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.ContactTitle) && baseCustomer.ContactTitle.Length > 30)
            {
                result.Success = false;
                result.Message = "El título del contacto no puede exceder los 30 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.Address) && baseCustomer.Address.Length > 60)
            {
                result.Success = false;
                result.Message = "La dirección no puede exceder los 60 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.City) && baseCustomer.City.Length > 15)
            {
                result.Success = false;
                result.Message = "La ciudad no puede exceder los 15 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.Region) && baseCustomer.Region.Length > 15)
            {
                result.Success = false;
                result.Message = "La región no puede exceder los 15 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.PostalCode) && baseCustomer.PostalCode.Length > 10)
            {
                result.Success = false;
                result.Message = "El código postal no puede exceder los 10 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.Country) && baseCustomer.Country.Length > 15)
            {
                result.Success = false;
                result.Message = "El país no puede exceder los 15 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.Phone) && baseCustomer.Phone.Length > 24)
            {
                result.Success = false;
                result.Message = "El teléfono no puede exceder los 24 caracteres.";
            }

            if (!string.IsNullOrEmpty(baseCustomer?.Fax) && baseCustomer.Fax.Length > 24)
            {
                result.Success = false;
                result.Message = "El fax no puede exceder los 24 caracteres.";
            }

            result.Success = true;
            result.Message = "El cliente es válido.";
            return result;
        }
    }
}
