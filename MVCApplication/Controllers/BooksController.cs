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
            var list = booksRepository.GetBooks().OrderBy(x=>x.BookName).ToList();
            return View( list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //var books = LibraryEntities.Book.Include(b => b.Publisher);
            //return View(books.ToList());
          return View(new Books());
        }
        [HttpPost]
        public ActionResult Create(Books model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    booksRepository.AddBook(model);
                    booksRepository.Save();
                    return RedirectToAction("BookIndex");
                        
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
           // ViewBag.Publisher_ID = new SelectList(LibraryEntities.Publisher, "PublisherID", "PublisherName", model.Publisher_ID);
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Books bks = booksRepository.GetBooksById(id);
            return View(bks);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Books bks = booksRepository.GetBooksById(id);
            return View(bks);
        }

        [HttpPost]
        public ActionResult Edit(Books book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    booksRepository.UpdateBook(book);
                    booksRepository.Save();
                    return RedirectToAction("BookIndex");
                }
            }
            catch (System.Data.DataException)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(book);

        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangeError)
        {
            if (saveChangeError.GetValueOrDefault())
            {
                ViewBag.Message = "Unable to save changes.Try again!";
            }
            Books book = booksRepository.GetBooksById(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Books book = booksRepository.GetBooksById(id);
                booksRepository.DeleteBook(id);
                booksRepository.Save();
            }
            catch (System.Data.DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary{
                    {"id", id }, { "saveChangesError", true } });
            }
            return RedirectToAction("BookIndex");
        }
    }
}