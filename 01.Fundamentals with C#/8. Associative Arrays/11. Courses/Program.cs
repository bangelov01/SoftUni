using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> courseBook = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArr = input.Split(" : ");

                string course = inputArr[0];
                string student = inputArr[1];

                if (!courseBook.ContainsKey(course))
                {
                    courseBook.Add(course, new List<string>() {student});
                }
                else
                {
                    courseBook[course].Add(student);
                }
            }

            foreach (var course in courseBook.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
