using System;
using BookShelf.Models;
using FluentNHibernate.Mapping;

namespace BookShelf.Maps
{
    public sealed class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
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