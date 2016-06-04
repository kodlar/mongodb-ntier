using System;
using System.Collections.Generic;
using System.Linq;
using Book.Domains;
using MongoDB.Bson;
using MongoDB.Driver;
using Book.Helpers;

namespace Book.Repository
{

    public class MongoRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepository()
        {
            MongoConnectionHelper<TEntity> entity = new MongoConnectionHelper<TEntity>();
            _collection = (IMongoCollection<TEntity>)entity.Collection();
        }
        public void Insert(TEntity entity)
        {
            _collection.InsertOneAsync(entity);
        }

        public TEntity Save(TEntity entity)
        {

            _collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {
                IsUpsert = true
            });

            return entity;
        }

        public void Delete(TEntity entity)
        {

            _collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }

        public IList<TEntity> SearchFor(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.AsQueryable().Where(predicate.Compile()).ToList();
        }

        public IList<TEntity> GetAll()
        {
            var lst = _collection.Find(new BsonDocument()).ToListAsync().Result;
            return lst;
        }

        public IList<TEntity> GetAllBySort(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, string sortItem, int sortType)
        {
            BsonDocument sort = new BsonDocument { { sortItem, sortType } };

            var result = _collection.Find(new BsonDocument()).Sort(sort).ToListAsync().Result;

            return result.AsQueryable().Where(predicate.Compile()).ToList();

        }

        public IList<TEntity> GetAllBySort(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, int page, int pageSize, string sortItem, int sortType)
        {
            BsonDocument sort = new BsonDocument { { sortItem, sortType } };

            var result = _collection.Find(new BsonDocument()).Limit(pageSize).Sort(sort).ToListAsync().Result;

            return result.AsQueryable().Where(predicate.Compile()).ToList();

        }



        public TEntity GetById(string id)
        {
            return _collection.Find(x => x.Id.Equals(new ObjectId(id))).FirstOrDefaultAsync().Result;
        }

        public IList<TEntity> GetPagedList(int page, int pageSize)
        {
            long count = 0;
            var lst = new List<TEntity>();
            int skip = (int)((page - 1) * pageSize);

            lst = _collection.Find(new BsonDocument()).Skip(skip).Limit(pageSize).ToListAsync().Result;
            count = _collection.CountAsync(new BsonDocument()).Result;

            var pagedList = new PagedListHelper<TEntity>(lst, page, pageSize, count);
            return pagedList;
        }


        public IList<TEntity> GetPagedListBySort(int page, int pageSize, string sortItem, int sortType)
        {
            long count = 0;
            var lst = new List<TEntity>();
            int skip = (int)((page - 1) * pageSize);

            BsonDocument sort = new BsonDocument { { sortItem, sortType } };

            lst = _collection.Find(new BsonDocument()).Sort(sort).Skip(skip).Limit(pageSize).ToListAsync().Result;

            count = _collection.CountAsync(new BsonDocument()).Result;

            var pagedList = new PagedListHelper<TEntity>(lst, page, pageSize, count);
            return pagedList;
        }

    }
}

