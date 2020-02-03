using MVCApplication.Models.BD;
using MVCApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace MVCApplication.Repositories
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly LibraryEntities _dbContext;
        public PublishersRepository()
        {
            _dbContext = new LibraryEntities();
        }
        public PublishersRepository(LibraryEntities context)
        {
            _dbContext = context;
        }

        //public void AddPublishers(Models.ViewModel.Publishers publisher)
        //{
        //    _dbContext.Publisher.Add(publisher);
        //    Save();
        //}

        //public void DeletePublishers(int id)
        //{
        //    var publisher = _dbContext.Publisher.Find(id);
        //    if (publisher != null)
        //    {
        //        _dbContext.Book.Remove(publisher);
        //    }
        //}

        public ReadOnlyCollection<Models.ViewModel.Publishers> GetPublishers()
        {
            return _dbContext.Publisher.ToList();
        }
        //public void UpdatePublishers(Models.BD.Publishers publisher)
        //{
        //    _dbContext.Entry(publisher).State = System.Data.Entity.EntityState.Modified;
        //}
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