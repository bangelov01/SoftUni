using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.UsersAndProductsDtos
{
    [XmlType]
    public class SoldProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }
        [XmlArray("products")]
        public UAPProductDto[] Products { get; set; }
    }
}
