using System.Collections.Generic;

namespace BookShelf.Models
{

    public interface IBookRepository
    {
        void Commit();
        void Rollback();
        Book GetById(int isbn);
        void Update(Book book);
        IList<Book> GetAll();
    }
}