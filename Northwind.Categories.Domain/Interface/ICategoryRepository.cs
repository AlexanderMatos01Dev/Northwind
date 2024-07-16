using Northwind.Categories.Domain.Entities;
using System.Linq.Expressions;

namespace Northwind.Categories.Domain.Interface
{
    public interface ICategoryRepository
    {
        List<Northwind.Categories.Domain.Entities.Category> GetCategories();
        bool Exists(Expression<Func<Category, bool>> filter);
        List<Category> GetAll();
        Category GetEntityBy(int id);
        void Remove(Category entity);
        void Save(Category entity);
        void Update(Category entity);
    }
}
