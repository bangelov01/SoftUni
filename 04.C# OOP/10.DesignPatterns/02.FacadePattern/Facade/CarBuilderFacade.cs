using _02.FacadePattern.Builders;
using _02.FacadePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FacadePattern.Facade
{
    public class CarBuilderFacade
    {
        protected Car Car;

        public CarBuilderFacade()
        {
            Car = new Car();
        }

        public Car Build() => this.Car;
        public CarInfoBuilder Info => new CarInfoBuilder(Car);
        public CarAddressBuilder Built => new CarAddressBuilder(Car);
    }
}
