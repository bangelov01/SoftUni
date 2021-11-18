using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Import
{
    public class SalesImportDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public decimal Discount { get; set; }
    }
}
