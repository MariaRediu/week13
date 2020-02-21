using MVCApplication.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCApplication.Repositories
{
   public interface IBooksRepository: IDisposable
    {

        IEnumerable<Books> GetBooks();
        Books GetBooksById(int id);
        void AddBook(Books book);
        void UpdateBook(Books book);
        void DeleteBook(int id);
        void Save();
        IEnumerable<SelectListItem> GetAllPublisher();
    }
}
