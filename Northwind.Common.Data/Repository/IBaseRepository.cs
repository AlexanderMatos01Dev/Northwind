using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Common.Data.Repository
{
    public interface IBaseRepository<TEntity,TType> where TEntity  : class 
    {
        void Save(TEntity entity);
        void update(TEntity entity);
        void remove(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetEntityBy(int Id);

        bool Exists(Expression<Func<TEntity, bool>> filter);

    }
    
}
