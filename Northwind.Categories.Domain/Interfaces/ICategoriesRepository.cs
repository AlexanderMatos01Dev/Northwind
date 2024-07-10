using Northwind.Common.Data.Repository;

namespace Northwind.Categories.Domain.Interfaces
{
    public interface ICategoriesRepository : IBaseRepository<Categories.Domain.Entities.Category,int>   
    {

    }
}
