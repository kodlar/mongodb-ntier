using Book.Domains;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Book.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        TEntity Save(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(string id);

        IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();

        IList<TEntity> GetAllBySort(Expression<Func<TEntity, bool>> predicate, string sortItem, int sortType);

        IList<TEntity> GetAllBySort(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, string sortItem, int sortType);

        IList<TEntity> GetPagedList(int page, int pageSize);

        IList<TEntity> GetPagedListBySort(int page, int pageSize, string sortItem, int sortType);



    }
}
