namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var neededPrisoners = context.Prisoners
                .Include(x => x.PrisonerOfficers)
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)

                    /*decimal.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2, MidpointRounding.AwayFromZero)*/
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(neededPrisoners, jsonSettings);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var separatedNames = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var prisoners = context.Prisoners
                .Include(x => x.Mails)
                .ToArray()
                .Where(p => separatedNames.Contains(p.FullName))
                .Select(p => new ExportInboxForPrisonerDTO
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new ExportMessageDTO
                    {
                        Description = new string(m.Description.ToCharArray().Reverse().ToArray())
                    })
                    .ToArray()
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("Prisoners", typeof(ExportInboxForPrisonerDTO[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, prisoners, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        private static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }
    }
}