namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = GetSerializer("Projects", typeof(ImportProjectDTO[]));

            var deserializedProjects = (ImportProjectDTO[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var filteredProjects = new HashSet<Project>();

            foreach (var project in deserializedProjects)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime opDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newProject = new Project
                {
                    Name = project.Name,
                    OpenDate = opDate,
                    DueDate = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dDate) ? dDate :(DateTime?)null
                };

                var filteredTasks = new HashSet<Task>();

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }


                    if (!DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpDate < newProject.OpenDate || taskDueDate > newProject.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    filteredTasks.Add(new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType
                    });
                }

                newProject.Tasks = filteredTasks;
                filteredProjects.Add(newProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, newProject.Name, newProject.Tasks.Count));

            }

            context.Projects.AddRange(filteredProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var desEmployees = JsonConvert.DeserializeObject<IEnumerable<ImportEmployeesDTO>>(jsonString);

            var sb = new StringBuilder();

            var filteredEmployees = new HashSet<Employee>();

            foreach (var e in desEmployees)
            {
                if (!IsValid(e))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newEmployee = new Employee
                {
                    Username = e.Username,
                    Email = e.Email,
                    Phone = e.Phone
                };

                var filteredTasks = new HashSet<EmployeeTask>();

                foreach (var t in e.Tasks.Distinct())
                {
                    if (context.Tasks.Find(t) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    filteredTasks.Add(new EmployeeTask
                    {
                        TaskId = t,
                        Employee = newEmployee
                    });
                }

                newEmployee.EmployeesTasks = filteredTasks;
                filteredEmployees.Add(newEmployee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, newEmployee.Username, newEmployee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(filteredEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}