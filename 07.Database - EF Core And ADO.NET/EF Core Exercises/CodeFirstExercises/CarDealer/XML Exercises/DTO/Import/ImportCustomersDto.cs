using System.Xml.Serialization;

namespace CarDealer.DTO.Import
{
    [XmlType("Customer")]
    public class ImportCustomersDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("birthDate")]
        public string BirthDate { get; set; }
        [XmlElement("isYoungDriver")]
        public string IsYoungDriver { get; set; }
    }
}
