using System;

namespace _18.Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalWage = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(0.35 * minimalWage);
            double scholarshipEscellent = Math.Floor(averageGrade * 25);

            if (income >= minimalWage && averageGrade >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {scholarshipEscellent} BGN");
            }
            else if (income >= minimalWage && averageGrade < 5.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (income < minimalWage && averageGrade >= 5.5 && socialScholarship <= scholarshipEscellent)
            {
                Console.WriteLine($"You get a scholarship for excellent results {scholarshipEscellent} BGN");
            }
            else if (income < minimalWage && averageGrade > 4.5)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (income < minimalWage && averageGrade <= 4.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
