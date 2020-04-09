using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Add(T itemToAdd);
        T Update(T itemToUpdate);
        bool Delete(T itemToDelete);
        T Delete(Guid id);
    }
}
