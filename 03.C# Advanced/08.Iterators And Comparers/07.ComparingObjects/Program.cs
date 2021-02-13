using System;
using System.Collections.Generic;

namespace _07.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string personInfo = string.Empty;

            List<Person> people = new List<Person>();

            while ((personInfo = Console.ReadLine()) != "END")
            {
                string[] personInfoArr = personInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfoArr[0];
                int age = int.Parse(personInfoArr[1]);
                string town = personInfoArr[2];

                Person newPerson = new Person(name, age, town);

                people.Add(newPerson);
            }

            int personNum = int.Parse(Console.ReadLine());
            var personToCompare = people[personNum - 1];
            int matchCount = 0;

            for (int i = 0; i < people.Count; i++)
            {
                int comparisonResult = personToCompare.CompareTo(people[i]);

                if (comparisonResult == 0)
                {
                    matchCount++;
                }
            }

            if (matchCount <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchCount} {people.Count - matchCount} {people.Count}");

            }
        }
    }
}
