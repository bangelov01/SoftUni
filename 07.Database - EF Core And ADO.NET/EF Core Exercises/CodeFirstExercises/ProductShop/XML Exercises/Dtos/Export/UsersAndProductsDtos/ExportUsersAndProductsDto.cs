using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.UsersAndProductsDtos
{
    [XmlType]
    public class ExportUsersAndProductsDto
    {
        [XmlElement("count")]
        public int UsersCount { get; set; }
        [XmlArray("users")]
        public UsersAndProductsDto[] Users { get; set; }
    }
}
