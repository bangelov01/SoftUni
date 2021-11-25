using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersAndPrisonersDTO
    {
        [XmlElement("Name")]
        [Required, MinLength(3), MaxLength(30)]
        public string FullName { get; set; }
        [XmlElement("Money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Salary { get; set; }
        [XmlElement("Position")]
        public string Position { get; set; }
        [XmlElement("Weapon")]
        public string Weapon { get; set; }
        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }
        [XmlArray("Prisoners")]
        public PrisonerDTO[] Prisoners { get; set; }
    }
}
