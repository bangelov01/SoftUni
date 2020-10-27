using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14._OrderByAge
{
    class Person
    {
        public Person(string name, int id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Person> people = new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split();

                string name = inputArr[0];
                int iD = int.Parse(inputArr[1]);
                int age = int.Parse(inputArr[2]);

                Person addPerson = new Person(name, iD, age);
                people.Add(addPerson);
            }

            List<Person> order = people.OrderBy(x => x.Age).ToList();

            foreach (Person person in order)
            {
                Console.WriteLine(person);
            }
        }
    }
}
