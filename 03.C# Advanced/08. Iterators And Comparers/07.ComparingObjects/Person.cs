using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _07.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person otherPerson)
        {
            if (Name.CompareTo(otherPerson.Name) != 0)
            {
                return Name.CompareTo(otherPerson.Name);
            }

            if (Age.CompareTo(otherPerson.Age) != 0)
            {
                return Age.CompareTo(otherPerson.Age);
            }

            if (Town.CompareTo(otherPerson.Town) != 0)
            {
                return Town.CompareTo(otherPerson.Town);
            }

            return 0;
        }
    }
}
