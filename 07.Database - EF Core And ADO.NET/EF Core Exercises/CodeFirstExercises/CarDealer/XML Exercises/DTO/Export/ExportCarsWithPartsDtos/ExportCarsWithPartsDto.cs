﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DTO.Export.ExportCarsWithPartsDtos
{
    [XmlType("car")]
    public class ExportCarsWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
        [XmlArray("parts")]
        public PartDto[] Parts { get; set; }
    }
}