using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MVCApplication.Models.BD;


namespace MVCApplication.Repositories
{
    public class BooksRepository:IBooksRepository
    {
        private readonly LibraryEntities _dbContext;

        public BooksRepository()
        {
            _dbContext = new LibraryEntities();
        }
        public BooksRepository(LibraryEntities context)
        {
            _dbContext = context;
        }
         public IEnumerable<Books> GetBooks()
        {
            return _dbContext.Book.ToList();
        }
        public Books GetBooksById(int? id)
        {
            return _dbContext.Book.Find(id); ;
        }

        public void AddBook(Books book)
        {
            _dbContext.Book.Add(book);
            Save();

        }
        public void UpdateBook(Books book)
        {
            _dbContext.Entry(book).State = System.Data.Entity.EntityState.Modified;
        }
       public void DeleteBook(int id)
        {
            var book = _dbContext.Book.Find(id);
            if (book != null)
            {
                _dbContext.Book.Remove(book);
            }
        }
       
       public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SelectListItem> GetAllPublisher()
        {
            IEnumerable<SelectListItem> list = _dbContext.Book.Select(s => new SelectListItem
            {
                Selected = false,
                Text = s.Publisher.PublisherName.ToString(),
                Value = s.Publisher.PublisherID.ToString()
            });
            return list;
        }
       

    }
}