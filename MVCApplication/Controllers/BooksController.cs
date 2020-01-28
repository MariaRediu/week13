using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApplication.Models.BD;
using MVCApplication.Repositories;

namespace MVCApplication.Controllers
{
    public class BooksController : Controller
    {
        private IBooksRepository booksRepository;

        public BooksController()
        {
            this.booksRepository = new BooksRepository(new LibraryEntities());
        }
        // GET: Books
        public ActionResult BookIndex()
        {
            var list = booksRepository.GetBooks().ToList();
            return View( list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Books());
        }
        [HttpPost]
        public ActionResult Create(Books books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    booksRepository.AddBook(books);
                    booksRepository.Save();
                    return RedirectToAction("BookIndex");
                        
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(books);
        }
    }
}