using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicturePlayerWeb.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAllItems();
        void Save(T item);
        T Delete(int itemId);
    }
}
