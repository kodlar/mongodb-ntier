using System.Collections.Generic;
using Book.Repository;

namespace Book.Services
{
    public class BookService:IBookService
    {
        private readonly IGenericRepository<Domains.BookEntity> _book;
 
        public BookService(IGenericRepository<Domains.BookEntity> book)
        {
            _book = book;
        }
        public IList<Domains.BookEntity> GetAll()
        {
            return _book.GetAll();
        }

        public Domains.BookEntity GetById(string id)
        {
            return _book.GetById(id);
        }

        public void Insert(Domains.BookEntity entity)
        {
             _book.Insert(entity);
        }

        public Domains.BookEntity Save(Domains.BookEntity entity)
        {
            return _book.Save(entity);
        }

    }
}
