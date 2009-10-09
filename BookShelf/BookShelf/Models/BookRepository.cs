using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using NHibernate;

namespace BookShelf.Models
{
    public class BookRepository
    {
        private readonly ISession _session;

        public BookRepository(ISession session)
        {
            if (session == null) throw new ArgumentNullException("session");
            _session = session;
        }

        
    }
}
