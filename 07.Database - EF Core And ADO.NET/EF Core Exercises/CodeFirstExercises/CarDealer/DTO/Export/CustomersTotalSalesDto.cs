using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Export
{
    public class CustomersTotalSalesDto
    {
        public string FullName { get; set; }
        public int BoughtCars { get; set; }
        public decimal SpentMoney { get; set; }
    }
}
