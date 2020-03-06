using Microsoft.EntityFrameworkCore;
using Model;
using Model.Interfaces;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class, IEntity
    {
        private readonly MovieDbContext _context;

        public RepositoryGeneric(MovieDbContext context)
        {
            _context = context;
        }
        
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T Create(T obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
            return obj;
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual T Update(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
            return obj;
        }

        public virtual bool Delete(int id)
        {
            var toRemove = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (toRemove == null) return false;

            _context.Set<T>().Remove(toRemove);
            _context.SaveChanges();
            return true;
        }
    }
}
