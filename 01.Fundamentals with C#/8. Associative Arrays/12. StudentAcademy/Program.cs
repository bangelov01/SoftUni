using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < rows; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>() {grade});
                }
                else
                {
                    students[name].Add(grade);
                }
            }

            Dictionary<string, double> sorted = new Dictionary<string, double>();

            foreach (var student in students)
            {
                double avgGrade = student.Value.Average();

                if (avgGrade >= 4.50)
                {
                    sorted.Add(student.Key, avgGrade);
                }

            }

            foreach (var item in sorted.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
