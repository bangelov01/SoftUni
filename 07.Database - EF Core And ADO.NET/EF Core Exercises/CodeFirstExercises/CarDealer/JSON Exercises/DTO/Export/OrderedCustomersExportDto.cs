using System;

namespace CarDealer.DTO.Export
{
    public class OrderedCustomersExportDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public bool IsYoungDriver { get; set; }
    }
}
