﻿using BookShelf.Models;
using FluentNHibernate.Mapping;

namespace BookShelf.Map
{
    public sealed class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Not.LazyLoad();
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