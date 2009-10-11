using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BookShelf.Models;

namespace BookShelf.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IPersonRepository _personRepository;
        public AuthorsController(IPersonRepository personRepository)
        {
            if (personRepository == null) throw new ArgumentNullException("personRepository");
            _personRepository = personRepository;
        }

        //
        // GET: /Authors/

        public ActionResult Index()
        {
            var persons = _personRepository.GetAll()
                .ToList();

            return View(persons);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Search(FormCollection collection)
        {
            
        }

    }

    
}
