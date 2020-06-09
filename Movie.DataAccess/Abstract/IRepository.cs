using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movie.DataAccess.Abstract
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int Id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
