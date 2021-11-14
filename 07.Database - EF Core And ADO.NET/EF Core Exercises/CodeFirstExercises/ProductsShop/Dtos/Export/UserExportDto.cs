using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    public class UserExportDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<SoldProductDto> SoldProducts { get; set; }
    }
}
