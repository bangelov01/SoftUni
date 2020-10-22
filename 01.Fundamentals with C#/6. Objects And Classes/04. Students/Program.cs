using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
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

                Student student = new Student();
                {
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Hometown = hometown;
                }

                students.Add(student);
            }

            string city = Console.ReadLine();

            List<Student> filter = students.Where(x => x.Hometown == city).ToList();

            foreach (Student student in filter)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old");
            }
        }
    }
}
