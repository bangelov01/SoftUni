using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int pairNum = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            while (pairNum > 0)
            {
                string[] person = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);

                Person newPerson = new Person(name, age);
                people.Add(newPerson);
                pairNum--;
            }

            string filter = Console.ReadLine();
            int ageOverOrUnder = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> condition = GetAgeCondition(filter, ageOverOrUnder);
            Func<Person, string> formatter = GetFormatter(format);

            PrintPeople(people, condition, formatter);
        }

        static Func<Person, bool> GetAgeCondition(string filter, int age)
        {
            switch (filter)
            {
                case "younger": return p => p.Age < age;
                case "older": return p => p.Age >= age;
                default:
                    return null;
            }
        }

        static void PrintPeople(List<Person> people, Func<Person, bool> condition, Func<Person,string> formatter)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formatter(person));
                }
            }
        }

        static Func<Person, string> GetFormatter(string format)
        {
            switch (format)
            {
                case "name": return p => $"{p.Name}";
                case "name age": return p => $"{p.Name} - {p.Age}";
                default:
                    return null;
            }
        }
    }
}
