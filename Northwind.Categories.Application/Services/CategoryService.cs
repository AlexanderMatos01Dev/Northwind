using Microsoft.Extensions.Logging;
using Northwind.Categories.Domain.Interface;
using Northwind.Categories.Domain.Entities;
using Northwind.Categories.Application.Contracts;
using Northwind.Categories.Application.Base;
using Northwind.Categories.Application.Dtos;
using Northwind.Categories.Application.Extensions;

namespace Northwind.Categories.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ILogger<CategoryService> logger;

        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            this.categoryRepository = categoryRepository;
            this.logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var categories = this.categoryRepository.GetAll();

                result.Result = (from category in categories
                                 select new CategoryDtoGetAll()
                                 {
                                     CategoryID = category.CategoryID,
                                     CategoryName = category.CategoryName
                                 }).ToList();

                result.Success = true;
                result.Message = "Categorías obtenidas exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener las categorías.";
                this.logger.LogError(result.Message, ex);
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var category = this.categoryRepository.GetEntityBy(id);

                if (category == null)
                {
                    result.Success = false;
                    result.Message = $"No se encontró la categoría con ID: {id}.";
                }
                else
                {
                    result.Result = new CategoryDtoGetAll()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                        Picture = category.Picture
                    };
                    result.Success = true;
                    result.Message = "Categoría obtenida exitosamente.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Add(CategoryDtoSave categoryDtoSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = categoryDtoSave.IsValidCategory();

                if (!result.Success)
                    return result;

                var category = new Category()
                {
                    CategoryName = categoryDtoSave.CategoryName,
                    Description = categoryDtoSave.Description,
                    Picture = categoryDtoSave.Picture
                };

                this.categoryRepository.Save(category);
                result.Success = true;
                result.Message = "Categoría añadida exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Update(CategoryDtoUpdate categoryDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = categoryDtoUpdate.IsValidCategory();

                if (!result.Success)
                    return result;

                var category = new Category()
                {
                    CategoryID = categoryDtoUpdate.CategoryID,
                    CategoryName = categoryDtoUpdate.CategoryName,
                    Description = categoryDtoUpdate.Description,
                    Picture = categoryDtoUpdate.Picture
                };

                this.categoryRepository.Update(category);
                result.Success = true;
                result.Message = "Categoría actualizada exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }

        public ServiceResult Remove(CategoryDtoRemove categoryDtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (categoryDtoRemove == null)
                {
                    result.Success = false;
                    result.Message = $"El objeto {nameof(categoryDtoRemove)} es requerido.";
                    return result;
                }

                var category = new Category()
                {
                    CategoryID = categoryDtoRemove.CategoryID
                };

                this.categoryRepository.Remove(category);
                result.Success = true;
                result.Message = "Categoría eliminada exitosamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar la categoría.";
                this.logger.LogError(result.Message, ex);
            }

            return result;
        }
    }
}
