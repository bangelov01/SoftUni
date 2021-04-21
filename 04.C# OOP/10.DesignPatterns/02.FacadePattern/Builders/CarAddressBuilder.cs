using _02.FacadePattern.Facade;
using _02.FacadePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FacadePattern.Builders
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }
        public CarAddressBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
