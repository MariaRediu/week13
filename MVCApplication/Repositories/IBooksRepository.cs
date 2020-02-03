using MVCApplication.Models.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.Repositories
{
   public interface IBooksRepository: IDisposable
    {
        IEnumerable<Books> GetBooks();
        Books GetBooksById(int id);
        void AddBook(Books model);
        void UpdateBook(Books model);
        void DeleteBook(int id);
        void Save();
    }
}
