using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesNum = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            while (linesNum > 0)
            {
                string[] peopleInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);

                Person newPerson = new Person(name, age);
                people.Add(newPerson);
                linesNum--;
            }

            Func<Person, bool> getPerson = GetOver30();

            List<Person> filtered = people.Where(getPerson).OrderBy(x => x.Name).ToList();

            foreach (var person in filtered)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }

        public static Func<Person, bool> GetOver30()
        {
            return x => x.Age > 30;
        }
    }
}
