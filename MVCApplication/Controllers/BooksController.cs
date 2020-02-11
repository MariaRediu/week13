using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abp.AutoMapper;
using MVCApplication.Models.BD;
using MVCApplication.Repositories;
using PagedList;


namespace MVCApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository booksRepository;
     

        public BooksController()
        {
            this.booksRepository = new BooksRepository(new LibraryEntities());
        }
        // GET: Books
        public ActionResult BookIndex(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam= String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var books = booksRepository.GetBooks();

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookName.Contains(searchString));
            }

            switch (sortOrder){
                case "name_desc":
                    books = books.OrderByDescending(x => x.BookName);
                    break;
                case "price_desc":
                    books = books.OrderBy(x => x.Price);
                    break;
                default:
                    books = books.OrderBy(x => x.BookName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
          
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.BD.Books());
        }
        [HttpPost]
        public ActionResult Create(Models.BD.Books book)
        {
            
                if (ModelState.IsValid)
                {
                    booksRepository.AddBook(book);
                    booksRepository.Save();
                    return RedirectToAction("BookIndex");
                        
                }
           //ViewBag.Publisher_ID = new SelectList(LibraryEntities.Publishers, "PublisherID", "PublisherName", book.Publisher_ID);
            return View(book);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Books book = booksRepository.GetBooksById(id);
            return View(book);
        }

        [HttpGet]
        public ActionResult Edit(int id = 1)
        {
          
            Books book = booksRepository.GetBooksById(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Books book,int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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

        [AutoMap(typeof(IEnumerable<Books>), typeof(IEnumerable<Books>))]
        public ActionResult BookListIndex()
        {
            
            IEnumerable<Books> books = booksRepository.GetBooks();

            return this.View(books);
        }
    }
}