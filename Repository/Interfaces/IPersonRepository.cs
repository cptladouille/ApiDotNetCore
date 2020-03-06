using System.Collections.Generic;
using Model.Entities;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAllPerson();
        Person Add(Person person);
        bool Delete(int id);
        Person Update(int id, Person person);
        Person Exists(Person person);
    }
}