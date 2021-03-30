using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private CarRepository carRepo;
        private DriverRepository driverRepo;
        private RaceRepository raceRepo;
        public ChampionshipController()
        {
            this.carRepo = new CarRepository();
            this.driverRepo = new DriverRepository();
            this.raceRepo = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = driverRepo.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var car = carRepo.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driver.Name, car.Model);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var driver = driverRepo.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driver.Name, race.Name);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var check = carRepo.GetByName(model);

            if (check != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar newCar = null;

            if (type == "Muscle")
            {
                newCar = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                newCar = new SportsCar(model, horsePower);
            }

            carRepo.Add(newCar);

            return string.Format(OutputMessages.CarCreated, newCar.GetType().Name, newCar.Model);
        }

        public string CreateDriver(string driverName)
        {
            var check = driverRepo.GetByName(driverName);

            if (check != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver newDriver = new Driver(driverName);

            driverRepo.Add(newDriver);

            return string.Format(OutputMessages.DriverCreated, newDriver.Name);
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepo.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace newRace = new Race(name, laps);

            raceRepo.Add(newRace);

            return string.Format(OutputMessages.RaceCreated, newRace.Name);
        }

        public string StartRace(string raceName)
        {
            var race = raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            int participantsThreshold = 3;

            if (race.Drivers.Count < participantsThreshold)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, race.Name, participantsThreshold));
            }

            var result = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < participantsThreshold; i++)
            {
                string place = string.Empty;

                if (i == 0)
                {
                    place = "wins";
                }
                else if (i == 1)
                {
                    place = "is second in";
                }
                else if (i == 2)
                {
                    place = "is third in";
                }

                sb.AppendLine($"Driver {result[i].Name} {place} {race.Name} race.");
            }

            raceRepo.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
