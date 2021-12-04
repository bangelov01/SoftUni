namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var neededProjects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectDTO
                {
                    TasksCount = p.Tasks.Count,
                    Name = p.Name,
                    HasEndDate = p.DueDate == null ? "No" : "Yes",
                    Tasks = p.Tasks.Select(t => new ExportTaskDTO
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(o => o.Name)
                    .ToArray()
                })
                .OrderByDescending(o => o.TasksCount)
                .ThenBy(o => o.Name)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);
                
            var serializer = GetSerializer("Projects", typeof(ExportProjectDTO[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, neededProjects, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var neededEmployees = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .OrderByDescending(o => o.Task.DueDate)
                    .ThenBy(o => o.Task.Name)
                    .Select(t => new
                    {
                        TaskName = t.Task.Name,
                        OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.Task.LabelType.ToString(),
                        ExecutionType = t.Task.ExecutionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(o => o.Tasks.Length)
                .ThenBy(o => o.Username)
                .Take(10)
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(neededEmployees, jsonSettings);
        }

        public static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }
    }
}