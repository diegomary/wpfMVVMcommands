using System.Collections.Generic;
using ControllsMVVM.Model;
using System.Collections.ObjectModel;

namespace ControllsMVVM.DataAccess
{
    public class PersonRespository
    {
        readonly List<Person> _persons;
        public PersonRespository()
        {
            if (_persons == null)
            {
                _persons = new List<Person>();
            }
            _persons.Add(new Person("Burt", "Lancaster"));
            _persons.Add(new Person("James", "Dean"));
            _persons.Add(new Person("Robert", "Pattinson"));
            _persons.Add(new Person("Gina", "Lollobrigida"));
            _persons.Add(new Person("Antony", "Hopkins"));
            _persons.Add(new Person("Richard", "Burton"));
        }

        public List<Person> GetPersons()
        {
            return new List<Person>(_persons);
        }
    }
}
