using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model.Database
{
    interface IGenericDAO<T>
    {
        List<T> GetAll();
       // int Add(T item);
       // bool Delete(int id);
       // void Update(int id, T item);
    }
}
