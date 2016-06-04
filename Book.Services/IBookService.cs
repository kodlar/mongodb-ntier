using System.Collections.Generic;
using MongoDB.Bson;

namespace Book.Services
{
    public interface IBookService 
    {
        void Insert(Domains.BookEntity entity);

        Domains.BookEntity Save(Domains.BookEntity entity);

        IList<Domains.BookEntity> GetAll();

        Domains.BookEntity GetById(string id);
     

    }
}
