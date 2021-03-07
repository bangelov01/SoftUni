using _10.ExplicitInterfaces.Contracts;
using System;

namespace _10.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();
                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);

                Citizen citizen = new Citizen(name, country, age);
                IResident resident = citizen;
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(resident.GetName());

            }
        }
    }
}
