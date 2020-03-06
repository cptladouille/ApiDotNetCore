using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Model;
using Model.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly MovieDbContext _context;

        public PersonRepository(MovieDbContext context)
        {
            this._context = context;
        }
        public List<Person> GetAllPerson()
        {
            return _context.Person.ToList();

        }

        public Person Add(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
            return person;
        }

        public bool Delete(int id)
        {
              var toDelete = GetAllPerson().Find(x => x.Id == id);
            if (toDelete == null)
            {
                return false;
            }
            _context.Person.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }

        public Person Update(int id, Person person)
        {
            Person toModify = GetAllPerson().Find(x => x.Id == id);
            person.Id = id;
            _context.Entry(toModify).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return toModify; 
        }


        public Person Exists(Person person)
        {
            return _context.Person.FirstOrDefault(x => x.FirstName == person.FirstName && x.LastName == person.LastName && x.BirthDate == person.BirthDate);
        }
    }
}