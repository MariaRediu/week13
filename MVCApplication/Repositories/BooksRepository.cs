using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public Books GetBooksById(int id)
        {
            return _dbContext.Book.Find(id); ;
        }

        public void AddBook(Books model)
        {
            _dbContext.Book.Add(model);
            Save();
        }
        public void UpdateBook(Books model)
        {
            _dbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
       public void DeleteBook(int id)
        {
            var model = _dbContext.Book.Find(id);
            if (model != null)
            {
                _dbContext.Book.Remove(model);
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

    }
}