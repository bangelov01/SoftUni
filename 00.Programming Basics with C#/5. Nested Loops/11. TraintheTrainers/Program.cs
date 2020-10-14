using System;

namespace _11._TraintheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            double people = double.Parse(Console.ReadLine());
            string presentation = Console.ReadLine();
            double averageGrade = 0;
            int gradeCount = 0;
            double save = 0;

            while (presentation != "Finish")
            {
                for (int i = 1; i <= people; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeCount++;
                    save += grade;
                    averageGrade += grade;
                }
                averageGrade /= people;
                Console.WriteLine($"{presentation} - {averageGrade:f2}.");
                averageGrade = 0;
                presentation = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {save/gradeCount:f2}.");

        }
    }
}
