using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.SoldProductDtos
{
    [XmlType("Product")]
    public class ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public string Price { get; set; }
    }
}
