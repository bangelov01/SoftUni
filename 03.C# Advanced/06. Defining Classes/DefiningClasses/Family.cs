using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }
        public List<Person> People { get; set; }

        public void AddMembers(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestPerson()
        {
            int maxAge = int.MinValue;

            Person holder = new Person();

            foreach (var person in People)
            {
                if (person.Age > maxAge)
                {
                    holder = person;
                    maxAge = person.Age;
                }
            }

            return holder;
        }
    }
}
