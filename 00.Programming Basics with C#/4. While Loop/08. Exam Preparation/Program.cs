using System;

namespace _08._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int unsatisfyingGrades = int.Parse(Console.ReadLine());
            double averageScore = 0.0;
            int problemsCount = 0;
            int poorGradeCunt = 0;
            string savedProblem = "";

            while (poorGradeCunt < unsatisfyingGrades)
            {
                string problem = Console.ReadLine();
                if (problem == "Enough")
                {
                    Console.WriteLine($"Average score: {averageScore / problemsCount:f2}");
                    Console.WriteLine($"Number of problems: {problemsCount}");
                    Console.WriteLine($"Last problem: {savedProblem}");
                    break;
                }
                savedProblem = problem;
                int score = int.Parse(Console.ReadLine());
                if (score <= 4)
                {
                    poorGradeCunt++;
                }
                averageScore += score;
                problemsCount++;

            }
            if (poorGradeCunt == unsatisfyingGrades)
            {
                Console.WriteLine($"You need a break, {poorGradeCunt} poor grades.");
            }
        }
    }
}
