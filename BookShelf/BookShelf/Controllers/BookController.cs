using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BookShelf.Models;

namespace BookShelf.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        //
        // GET: /Book/

        public ActionResult Index()
        {
            var books = _repository.GetAll();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _repository.GetById(id);
            return book == null ? View("NotFound") : View(book);
        }

        public ActionResult Create()
        {
            var book = new Book();
            return View(book);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UpdateModel(book);
                    _repository.Update(book);
                    _repository.Commit();
                    return RedirectToAction("Details", new {id = book.Isbn});
                } catch 
                {
                    var errors = book.GetErrorMessages();
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Property, error.ErrorMessage);
                    }
                }
            }
            return View(book);
        }
    }
}
