using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArr = input.Split(" -> ");

                string company = inputArr[0];
                string employeeId = inputArr[1];

                if (!employees.ContainsKey(company))
                {
                    employees.Add(company, new List<string>() { employeeId });
                }
                else
                {
                    if (!employees[company].Contains(employeeId))
                    {
                        employees[company].Add(employeeId);
                    }
                }
            }

            foreach (var company in employees.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
