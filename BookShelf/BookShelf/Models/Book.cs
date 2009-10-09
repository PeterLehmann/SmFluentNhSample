namespace BookShelf.Models
{
    public class Book
    {
        private Book()
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
    }
}
