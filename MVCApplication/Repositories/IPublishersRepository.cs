using MVCApplication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCApplication.Repositories
{
  public interface IPublishersRepository : IDisposable
    {
        IEnumerable<Publishers> GetPublishers();
        //void AddPublishers(Publishers publisher);
        //void UpdatePublishers(Publishers publisher);
        //void DeletePublishers(int id);
        void Save();
    }
}
