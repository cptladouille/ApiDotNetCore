using System;
using System.Collections.Generic;
using System.Text;
using Model.Interfaces;
using Repository.Interfaces;
using Service.interfaces;

namespace Service.Services
{
    public class ServiceGeneric<T> : IServiceGeneric<T> where T : class, IEntity
    {
        private IRepositoryGeneric<T> _repo;

        public ServiceGeneric(IRepositoryGeneric<T> repo)
        {
            _repo = repo;
        }

        public virtual T Create(T obj)
        {
            return _repo.Create(obj);
        }

        public virtual T Get(int id)
        {
            return _repo.Get(id);
        }

        public virtual T Update(T obj)
        {
            return _repo.Update(obj);
        }

        public virtual bool Delete(int id)
        {
            return _repo.Delete(id);
        }

        public virtual List<T> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
