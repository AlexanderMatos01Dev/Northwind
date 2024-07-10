using Northwind.Categories.Domain.Interfaces;
using System.Linq.Expressions;

namespace Northwind.Categories.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public bool Exists(Expression<Func<Domain.Entities.Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Category GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void remove(Domain.Entities.Category entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Category entity)
        {
            throw new NotImplementedException();
        }

        public void update(Domain.Entities.Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
