﻿using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Product")]
    public class ExportProductInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]
        public string Price { get; set; }
        [XmlElement("buyer")]
        public string BuyerName { get; set; }
    }
}
