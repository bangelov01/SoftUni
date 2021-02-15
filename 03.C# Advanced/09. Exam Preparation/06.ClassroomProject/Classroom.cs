using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
   public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }          
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var neededStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
             
             if (neededStudent != null)
             {            
                 students.Remove(neededStudent);
                 return $"Dismissed student {neededStudent.FirstName} {neededStudent.LastName}";
             }
             
             return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            var neededStudents = students.Where(x => x.Subject == subject);

            if (neededStudents.Count() > 0)
            {
                foreach (var item in neededStudents)
                {
                    sb.AppendLine($"{item.FirstName} {item.LastName}");
                }
                return sb.ToString().Trim();
            }
            else
            {
                return "No students enrolled for the subject";
            }

        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
