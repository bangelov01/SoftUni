using System;
using System.Collections.Generic;
using System.Text;
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
