using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            string studentDetails = string.Empty;

            while ((studentDetails = Console.ReadLine()) != "end")
            {
                string[] splitDetails = studentDetails.Split();

                string firstName = splitDetails[0];
                string lastName = splitDetails[1];
                string age = splitDetails[2];
                string hometown = splitDetails[3];

                Student Student = students.FirstOrDefault(y => y.FirstName == firstName && y.LastName == lastName);

                if (Student == null)
                {
                    students.Add(new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = hometown
                    });
                }

                else
                {
                   Student.FirstName = firstName;
                   Student.LastName = lastName;
                   Student.Age = age;
                   Student.Hometown = hometown;
                }

            }

            string city = Console.ReadLine();

            List<Student> filter = students.Where(x => x.Hometown == city).ToList();

            foreach (Student student in filter)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
