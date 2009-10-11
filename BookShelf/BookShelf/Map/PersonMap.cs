using System;
using BookShelf.Models;
using FluentNHibernate.Mapping;

namespace BookShelf.Map
{
    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Not.LazyLoad();
            Id(x => x.PersonId)
                .UnsavedValue(Guid.Empty)
                .Not.Nullable()
                .GeneratedBy.Guid();
            Map(x => x.FirstName)
                .Not.Nullable();
            Map(x => x.LastName)
                .Not.Nullable();
        } 
    }
}