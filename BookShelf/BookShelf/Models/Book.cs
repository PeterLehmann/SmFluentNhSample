using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Models
{
    public class Book : IVaild
    {
        public Book()
        {
        }

        public Book(int isbn, Person author)
        {
            Isbn = isbn;
            Author = author;
        }

        public int Isbn { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Person Author { get; private set; }
        
        public void IsVaild()
        {
            var errors = GetErrorMessages();
            if(errors.Any())
                throw new VaildException();
        }

        public IEnumerable<VaildMessage> GetErrorMessages()
        {
            if(Isbn == 0) yield return new VaildMessage("Isbn", "Isbn can not be zero");
            if(string.IsNullOrEmpty(Title)) yield return new VaildMessage("Title", "Title can not be null or empty");
            if (Author == null) yield return new VaildMessage("Author", "a book can not have a author");
        }
    }
}
