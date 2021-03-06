﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace BookShelf.Models
{
    public class BookRepository : IBookRepository
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        public BookRepository(ISession session)
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
        
        public Book GetById(int isbn)
        {
            var book = _session.Get<Book>(isbn);
            return book;
        }

        public void Update(Book book)
        {
            if (book == null) throw new ArgumentNullException("book");
            _session.SaveOrUpdate(book);
        }

        public IList<Book> GetAll()
        {
            return _session.Linq<Book>().ToList();
        }
    }
}
