using System;

namespace _23.Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int course = (int)Math.Ceiling((double)numberOfPeople / capacity);

            Console.WriteLine(course);

        }
    }
}
