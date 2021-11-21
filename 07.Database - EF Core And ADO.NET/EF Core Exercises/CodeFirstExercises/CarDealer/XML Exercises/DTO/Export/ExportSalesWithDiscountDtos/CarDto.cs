﻿using System.Xml.Serialization;

namespace CarDealer.DTO.Export.ExportSalesWithDiscountDtos
{
    [XmlType]
    public class CarDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
