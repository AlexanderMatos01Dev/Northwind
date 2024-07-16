using Northwind.Categories.Application.Base;
using Northwind.Categories.Application.Dtos;

namespace Northwind.Categories.Application.Extensions
{
    public static class ValidateCategory
    {
        public static ServiceResult IsValidCategory(this CategoryDtoBase baseCategory)
        {
            ServiceResult result = new ServiceResult();

            if (baseCategory is null)
            {
                result.Success = false;
                result.Message = $"El objeto {nameof(baseCategory)} es requerido.";
                return result;
            }

            if (string.IsNullOrEmpty(baseCategory?.CategoryName))
            {
                result.Success = false;
                result.Message = $"El nombre de la categoría es requerido.";
                return result;
            }

            // Adaptando las validaciones para que solo contengan propiedades relevantes
            if (baseCategory?.Description != null && baseCategory.Description.Length > 500)
            {
                result.Success = false;
                result.Message = $"La descripción de la categoría no puede exceder los 500 caracteres.";
                return result;
            }

            if (baseCategory?.Picture != null && baseCategory.Picture.Length > 1024 * 1024) // 1 MB
            {
                result.Success = false;
                result.Message = $"La imagen de la categoría no puede exceder 1 MB.";
                return result;
            }

            result.Success = true;
            result.Message = "La categoría es válida.";
            return result;
        }
    }
}
