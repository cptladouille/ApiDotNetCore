using System.Collections.Generic;
using Model.Interfaces;

namespace Service.interfaces
{
    public interface IServiceGeneric<T> where T : class, IEntity
    {
        T Create(T obj);
        T Get(int id);
        T Update(T obj);
        bool Delete(int id);
        List<T> GetAll();
    }
}
