using System;

namespace _05._Graduation_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double averageGrade = 0.0;
            int yearsCount = 0;
            int failCount = 1;

            while (true)
            {
                double grade = double.Parse(Console.ReadLine());
                yearsCount++;
                averageGrade += grade;
                if (grade < 4.00)
                {
                    failCount++;
                }
                if (failCount == 2)
                {
                    Console.WriteLine($"{name} has been excluded at {yearsCount} grade");
                    break;
                }
                if (yearsCount == 12)
                {
                    Console.WriteLine($"{name} graduated. Average grade: {averageGrade/yearsCount:f2}");
                    break;
                }
            }
        }
    }
}
