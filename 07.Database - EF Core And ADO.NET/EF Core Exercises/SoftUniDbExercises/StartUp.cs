using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            //var result = GetEmployeesFullInformation(context);
            //var result = GetEmployeesWithSalaryOver50000(context);
            //var result = GetEmployeesFromResearchAndDevelopment(context);
            //var result = AddNewAddressToEmployee(context);
            //var result = GetEmployeesInPeriod(context);
            //var result = GetAddressesByTown(context);
            //var result = GetEmployee147(context);
            //var result = GetDepartmentsWithMoreThan5Employees(context);
            //var result = GetLatestProjects(context);
            var result = IncreaseSalaries(context);
            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    MiddleName = e.MiddleName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = $"{e.Salary:f2}"
                }).ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    Name = e.FirstName,
                    Salary = e.Salary
                }).ToArray();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Name} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmenName = e.Department.Name,
                    Salary = e.Salary
                }).ToArray();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmenName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {

            var neededEmployee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            neededEmployee.Address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.SaveChanges();

            var employeesAddress = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(ea => new
                {
                    EmployeeAddress = ea.Address.AddressText
                }).ToArray();

            var sb = new StringBuilder();

            foreach (var a in employeesAddress)
            {
                sb.AppendLine(a.EmployeeAddress);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStartDate = p.Project.StartDate,
                        ProjectEndDate = p.Project.EndDate,
                    })
                })
                .Where(e => e.Projects
                             .Any(ep => ep.ProjectStartDate.Year >= 2001 &&                              ep.ProjectStartDate.Year <= 2003))
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    var endDate = p.ProjectEndDate.HasValue ? p.ProjectEndDate.ToString() : "not finished";

                    sb.AppendLine($"--{p.ProjectName} - {p.ProjectStartDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    a.Town.Name,
                    a.Employees.Count
                })
                .OrderByDescending(emp => emp.Count)
                .ThenBy(town => town.Name)
                .ThenBy(addr => addr.AddressText)
                .Take(10)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var addrInfo in addresses)
            {
                sb.AppendLine($"{addrInfo.AddressText}, {addrInfo.Name} - {addrInfo.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                                .Select(p => new
                                {
                                    p.Project.Name
                                })
                })
                .FirstOrDefault();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var p in employee.Projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                                 .Select(e => new
                                 {
                                     EmployeeFirstName = e.FirstName,
                                     EmployeeLastName = e.LastName,
                                     EmployeeJobTitle = e.JobTitle
                                 })
                })
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.DepartmentName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees.OrderBy(e => e.EmployeeFirstName).ThenBy(e => e.EmployeeLastName))
                {
                    sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.EmployeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToArray();


            var sb = new StringBuilder();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var neededEmployees = context.Employees
                .Where(e => departments.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in neededEmployees)
            {
                e.Salary *= 1.12M;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var e in neededEmployees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
