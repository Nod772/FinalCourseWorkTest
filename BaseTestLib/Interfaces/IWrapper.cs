using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTestLib.Interfaces
{
    public interface IWrapper<T>
    {
        void AddItem(T item);
        IEnumerable<T> GetItems();
        void UpdateItem(T item);
        void Delete(T item);
        T Find(T entry);
    }
}
