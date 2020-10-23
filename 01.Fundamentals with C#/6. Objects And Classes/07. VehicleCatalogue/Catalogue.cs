using System;
using System.Collections.Generic;
using System.Text;

namespace _07._VehicleCatalogue
{
    class Catalogue
    {
        public Catalogue()
        {
            Cars = new List<Cars>();

            Trucks = new List<Trucks>();
        }
        public List<Cars> Cars { get; set; }
        public List<Trucks> Trucks { get; set; }
    }
}
