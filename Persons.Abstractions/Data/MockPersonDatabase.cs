using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Abstractions.Data
{
    public static class MockPersonDatabase
    {
        public static IList<Person> Persons { get; }

        static MockPersonDatabase()
        {
            Persons = new List<Person>()
            {
                new Person() { Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709"), Name = "Васька", BirthDay = new DateTime(2008, 3, 9, 16, 5, 7, 123)
        },
                new Person() { Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857710"), Name = "Сашка", BirthDay = new DateTime(2008, 3, 9, 16, 5, 7, 123)
        },
                new Person() { Id = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857711"), Name = "Петька", BirthDay = new DateTime(2008, 3, 9, 16, 5, 7, 123)
        }
            };
        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime _birthDay { get; set; }
        public DateTime BirthDay
        {
            get { return _birthDay; }
            set
            {
                _birthDay = value;
                Age = GetAge(value);
            }
        }

        private int _age;
        public int? Age
        {
            get
            {
                if (_age > 120 || Name == null)
                    return null;
                return _age;
            }
            set { _age = (int)value; }
        }

        private int GetAge(DateTime birthDay)
        {
            int curYear = DateTime.Now.Year;
            int curMonth = DateTime.Now.Month;
            int curDay = DateTime.Now.Day;

            _age = curYear - BirthDay.Year;
            if (curMonth < BirthDay.Month && curDay < BirthDay.Day)
                return _age - 1;
            return _age;
        }
    }
}
