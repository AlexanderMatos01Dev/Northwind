using Northwind.Categories.Application.Base;
using Northwind.Categories.Application.Dtos;

namespace Northwind.Categories.Application.Contracts
{
    public interface ICategoryService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
        ServiceResult Add(CategoryDtoSave category);
        ServiceResult Update(CategoryDtoUpdate category);
        ServiceResult Remove(CategoryDtoRemove category);
    }
}
