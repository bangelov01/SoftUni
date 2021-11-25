namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

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
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var desPrisonersMails= JsonConvert.DeserializeObject<IEnumerable<ImportPrisonersAndMailsDTO>>(jsonString);

            var filteredPrisoners = new HashSet<Prisoner>();
            var sb = new StringBuilder();

            foreach (var prisoner in desPrisonersMails)
            {
                var mails = new HashSet<Mail>();

                bool isMailValid = true;

                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        isMailValid = false;
                        break;
                    }

                    mails.Add(new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    });
                }

                if (!IsValid(prisoner) || !isMailValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var validPrisoner = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = string.IsNullOrEmpty(prisoner.ReleaseDate) ? (DateTime?)null : DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisoner.Bail,
                    Mails = mails
                };

                filteredPrisoners.Add(validPrisoner);
                sb.AppendLine($"Imported {validPrisoner.FullName} {validPrisoner.Age} years old");
            }

            context.Prisoners.AddRange(filteredPrisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = GetSerializer("Officers", typeof(ImportOfficersAndPrisonersDTO[]));

            var deserializedOfficers = (ImportOfficersAndPrisonersDTO[])serializer.Deserialize(new StringReader(xmlString));

            var validatedOfficers = new HashSet<Officer>();

            var sb = new StringBuilder();

            foreach (var off in deserializedOfficers)
            {
                Weapon weaponValue;
                Position positionValue;

                var weapon = Enum.TryParse(off.Weapon, out weaponValue);
                var position = Enum.TryParse(off.Position, out positionValue);

                if (!IsValid(off) || !weapon || !position)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var validOfficer = new Officer
                {
                    FullName = off.FullName,
                    Salary = off.Salary,
                    Position = positionValue,
                    Weapon = weaponValue,
                    DepartmentId = off.DepartmentId
                };

                foreach (var prisonerId in off.Prisoners.Select(p => p.Id))
                {
                    validOfficer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        PrisonerId = prisonerId,
                        Officer = validOfficer
                    });
                };

                validatedOfficers.Add(validOfficer);
                sb.AppendLine($"Imported {validOfficer.FullName} ({validOfficer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validatedOfficers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
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