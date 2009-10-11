using System;
using NHibernate;
using System.Linq;
using NHibernate.Linq;

namespace BookShelf.Models
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        public PersonRepository(ISession session)
        {
            if (session == null) throw new ArgumentNullException("session");
            _session = session;
            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public IQueryable<Person> GetAll()
        {
            var query = _session.Linq<Person>();
            return query;
        }

        public IQueryable<Person> GetBySearchOption(PersonSearchOptions options)
        {
            if (options == null) throw new ArgumentNullException("options");
            IQueryable<Person> query = _session.Linq<Person>();
            if (!string.IsNullOrEmpty(options.FirstName))
            {
                query = query.Where(x => x.FirstName == options.FirstName);
            }

            if (!string.IsNullOrEmpty(options.LastName))
            {
                query = query.Where(x => x.LastName == options.LastName);
            }

            return query;
        }
    }

    public class PersonSearchOptions
    {
        public string FirstName { get; set; }

        public string LastName
        {
            get;
            set;
        }
    }
}