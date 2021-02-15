namespace ClassroomProject
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Classroom classroom = new Classroom(2);

            Student newStudent1 = new Student("Pesho", "Pesheca", "Maths");
            Student newStudent2 = new Student("Gosho", "Goshkata", "Algebra");
            Student newStudent3 = new Student("Misho", "Mishkata", "Algebra");
            Student newStudent4 = new Student("Dimo", "Dimeca", "Music");

            int count = classroom.GetStudentsCount();
            Console.WriteLine(count);

            string add = classroom.RegisterStudent(newStudent1);
            string add2 = classroom.RegisterStudent(newStudent2);

            Console.WriteLine(add);
            Console.WriteLine(add2);

            string sub = classroom.GetSubjectInfo("Algebra");
            string sub1 = classroom.GetSubjectInfo("Music");

            Console.WriteLine(sub);
            Console.WriteLine(sub1);

            string dis = classroom.DismissStudent("Pesho", "maniaka");

            string dis1 = classroom.DismissStudent("Pesho", "Pesheca");

            Console.WriteLine(dis);
            Console.WriteLine(dis1);

            int count2 = classroom.GetStudentsCount();
            Console.WriteLine(count2);

        }
    }
}