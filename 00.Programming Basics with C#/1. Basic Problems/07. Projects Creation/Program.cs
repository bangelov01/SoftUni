using System;

namespace _07._Projects_Creation
{
    class Program
    {
        static void Main(string[] args)
        {
            string architectName = Console.ReadLine();
            int numberOfProjects = int.Parse(Console.ReadLine());
            int numberOfHours = 3;
            int neededHours = numberOfProjects * numberOfHours;

            Console.WriteLine($"The architect {architectName} will need {neededHours} hours to complete {numberOfProjects} project/s.");
        }
    }
}
