using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            double bonus = double.Parse(Console.ReadLine());

            double saveTotalBonus = 0;
            double saveAtt = 0;

            for (int i = 0; i < studentCount; i++)
            {
                double attendanceCount = double.Parse(Console.ReadLine());
                double totalBonus = attendanceCount / lecturesCount * (5 + bonus);
                if (totalBonus > saveTotalBonus)
                {
                    saveTotalBonus = totalBonus;
                    saveAtt = attendanceCount;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(saveTotalBonus)}.");
            Console.WriteLine($"The student has attended {Math.Ceiling(saveAtt)} lectures.");
        }
    }
}
