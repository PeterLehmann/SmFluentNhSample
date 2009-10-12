using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelf.Models
{
    public interface IPersonRepository
    {
        void Commit();
        void Rollback();
        IQueryable<Person> GetAll();
        IQueryable<Person> GetBySearchOption(PersonSearchOptions options);
        void Save(Person person);
        void Update(Person person);
    }
}
