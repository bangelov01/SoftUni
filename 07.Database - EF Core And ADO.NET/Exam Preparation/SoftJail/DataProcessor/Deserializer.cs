namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var desDepCells = JsonConvert.DeserializeObject<IEnumerable<ImportDepartmentsAndCellsDTO>>(jsonString);

            var filteredDepartments = new List<Department>();
            var sb = new StringBuilder();

            foreach (var dep in desDepCells)
            {
                var cells = new List<Cell>();

                bool isCellValid = true;

                foreach (var cell in dep.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isCellValid = false;
                        break;
                    }

                    cells.Add(new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    });
                }

                if (!IsValid(dep) || !dep.Cells.Any() || !isCellValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var validDep = new Department
                {
                    Name = dep.Name,
                    Cells = cells
                };

                filteredDepartments.Add(validDep);

                sb.AppendLine($"Imported {validDep.Name} with {validDep.Cells.Count} cells");
            }

            context.Departments.AddRange(filteredDepartments);
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            throw new NotImplementedException();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}