using System;
using System.Collections.Generic;
using System.Text;

namespace _13._VehicleCatalogueV2
{
    class Catalogue
    {
        public Catalogue()
        {
            Vehicle = new List<Vehicle>();
        }
        public List<Vehicle> Vehicle { get; set; }
    }
}
