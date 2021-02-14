using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new List<Employee>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public void Add (Employee employee)
        {
            if (Count <= Capacity)
            {
                employees.Add(employee);
                Count++;
            }
        }

        public bool Remove(string name)
        {
            var emp = employees.FirstOrDefault(x => x.Name == name);
            if (emp == null)
            {
                return false;
            }

            employees.Remove(emp);
            Count--;
            return true;
        }

        public Employee GetOldestEmployee()
        {
            int maxAge = int.MinValue;

            foreach (var item in employees)
            {
                if (item.Age > maxAge)
                {
                    maxAge = item.Age;
                }
            }

            var emp = employees.FirstOrDefault(x => x.Age == maxAge);

            return emp;
        }

        public Employee GetEmployee(string name)
        {
            foreach (var employee in employees)
            {
                if (employee.Name == name)
                {
                    return employee;
                }
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var item in employees)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        } 
    }
}
