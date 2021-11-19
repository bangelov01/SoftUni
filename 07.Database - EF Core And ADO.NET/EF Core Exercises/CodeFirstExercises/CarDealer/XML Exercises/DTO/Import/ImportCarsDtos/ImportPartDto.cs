using System.Xml.Serialization;

namespace CarDealer.DTO.Import.ImportCarsDtos
{
    [XmlType("partId")]
    public class ImportPartDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
