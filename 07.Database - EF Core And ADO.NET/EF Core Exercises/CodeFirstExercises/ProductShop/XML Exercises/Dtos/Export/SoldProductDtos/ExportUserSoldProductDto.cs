﻿using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.SoldProductDtos
{
    [XmlType("User")]
    public class ExportUserSoldProductDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }
        [XmlElement("lastName")]
        public string LastName { get; set; }
        [XmlArray("soldProducts")]
        public ProductDto[] Products { get; set; }
    }
}
