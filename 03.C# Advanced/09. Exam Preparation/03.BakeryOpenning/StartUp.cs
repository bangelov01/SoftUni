namespace BakeryOpenning
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            Bakery bakery = new Bakery("Barny", 10);

            Employee employee = new Employee("Stephen", 40, "Bulgaria");

            Console.WriteLine(employee);
            bakery.Add(employee);
            Console.WriteLine(bakery.Remove("Employee name"));

            Employee secondEmployee = new Employee("Mark", 34, "UK");

            bakery.Add(secondEmployee);

            Employee oldestEmployee = bakery.GetOldestEmployee();
            Employee employeeStephen = bakery.GetEmployee("Stephen");
            Console.WriteLine(oldestEmployee); 
            Console.WriteLine(employeeStephen); 

            Console.WriteLine(bakery.Count); //2

            Console.WriteLine(bakery.Report());


        }
    }
}
