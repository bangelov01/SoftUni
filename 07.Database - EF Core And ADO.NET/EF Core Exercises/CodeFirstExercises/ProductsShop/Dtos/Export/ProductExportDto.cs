using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    public class ProductExportDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Seller { get; set; }
    }
}
