using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbigliamento_Task.DAL
{
    internal interface IDal<T>
    {
        List<T> GetAll();
        T GetbyId(int id);
        bool Insert(T t);
        bool Delete(T t);
        bool Update(T t);
    }
}
