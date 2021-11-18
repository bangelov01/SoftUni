using CarDealer.DTO.Export.CarsWithListOfPartsDtos;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO.Export
{
    public class CarsWithPartsListDto
    {
        [JsonProperty(PropertyName = "car")]
        public CarDto Car { get; set; }
        [JsonProperty(PropertyName = "parts")]
        public IEnumerable<PartDto> Parts { get; set; }
    }
}
