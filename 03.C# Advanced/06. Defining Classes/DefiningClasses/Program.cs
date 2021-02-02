using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int memberNum = int.Parse(Console.ReadLine());
            Family family = new Family();

            while ( memberNum > 0)
            {
                string[] memberInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                Person newPerson = new Person()
                {
                    Name = name,
                    Age = age
                };

                family.AddMembers(newPerson);
                
                memberNum--;
            }

            Person printPerson = family.GetOldestPerson();

            Console.WriteLine($"{printPerson.Name} {printPerson.Age}");
        }
    }
}
