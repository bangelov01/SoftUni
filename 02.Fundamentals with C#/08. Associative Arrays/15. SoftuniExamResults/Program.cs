using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._SoftuniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, int> studentsAndPoints = new Dictionary<string, int>();
            Dictionary<string, int> courses = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArr = input.Split("-");

                string name = inputArr[0];

                if (inputArr.Length > 2)
                {
                    string language = inputArr[1];
                    int points = int.Parse(inputArr[2]);

                    if (!studentsAndPoints.ContainsKey(name))
                    {
                        studentsAndPoints.Add(name, points);
                        if (!courses.ContainsKey(language))
                        {
                            courses.Add(language, 1);
                        }
                        else
                        {
                            courses[language]++;
                        }
                    }
                    else
                    {
                        if (studentsAndPoints[name] < points)
                        {
                            studentsAndPoints[name] = points;
                        }
                        if (!courses.ContainsKey(language))
                        {
                            courses.Add(language, 1);
                        }
                        else
                        {
                            courses[language]++;
                        }
                    }
                }
                else
                {
                    string nameToBan = inputArr[0];

                    studentsAndPoints.Remove(nameToBan);
                }
            }


            Console.WriteLine("Results:");

            foreach (var item in studentsAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var lang in courses.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
        }
    }
}
