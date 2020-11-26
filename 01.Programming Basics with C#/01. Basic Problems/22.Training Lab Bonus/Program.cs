using System;

namespace _22.Training_Lab_Bonus
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double widthTrue = (width * 100) - 100;
            int numberOfDesksWidth = (int)(widthTrue / 70);

            double lenghtTrue = lenght * 100;
            int numberOfDesksLenght = (int)(lenghtTrue / 120);

            int totalDesks = (numberOfDesksWidth * numberOfDesksLenght) - 3;

            Console.WriteLine(totalDesks);





        }
    }
}
