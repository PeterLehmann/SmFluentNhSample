using BookShelf.Models;
using FluentNHibernate.Mapping;

namespace BookShelf.Maps
{
    public sealed class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Id(x => x.Isbn)
                .Not.Nullable()
                .GeneratedBy.Assigned()
                .UnsavedValue(0);
            Map(x => x.Description)
                .Nullable();
            Map(x => x.Title)
                .Not.Nullable();
            References<Person>(x => x.Author)
                .Cascade.None()
                .Column("AuthorId")
                .LazyLoad();
        }
    }
}
