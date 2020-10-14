using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(PrintGrade(double.Parse(Console.ReadLine())));
        }

        static string PrintGrade(double grade)
        {
            if (grade >= 2.00 && grade <= 2.99)
            {
                return "Fail";
            }
            else if (grade > 2.99 && grade <= 3.49)
            {
                return "Poor";
            }
            else if (grade > 3.50 && grade <= 4.49)
            {
                return "Good";
            }
            else if (grade > 4.50 && grade <= 5.49)
            {
                return "Very good";
            }
            else
            {
                return "Excellent";
            }
        }
    }
}
