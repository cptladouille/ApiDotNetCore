using System;
using System.Collections.Generic;
using System.Text;
using Model.Interfaces;

namespace Repository.Interfaces
{
    public interface IRepositoryGeneric<T> where T : IEntity
    {
        T Create(T obj);
        T Get(int id);
        T Update(T obj);
        bool Delete(int id);
        List<T> GetAll();
    }
}
