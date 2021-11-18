using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

using CarDealer.Data;
using CarDealer.DTO.Import;
using CarDealer.Models;

using AutoMapper;
using CarDealer.DTO.Import.ImportCarsDtos;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliersFromXml = File.ReadAllText("Datasets/suppliers.xml");
            var partsFromXml = File.ReadAllText("Datasets/parts.xml");
            var carsFromXml = File.ReadAllText("Datasets/cars.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersFromXml));
            Console.WriteLine(ImportParts(context, partsFromXml));
            Console.WriteLine(ImportCars(context, carsFromXml));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = GetSerializer("Suppliers", typeof(ImportSuppliersDto[]));

            var deserializedSuppliers = (ImportSuppliersDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedSuppliers = InitializeMapper().Map<IEnumerable<Supplier>>(deserializedSuppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = GetSerializer("Parts", typeof(ImportPartsDto[]));

            var deserializedParts = (ImportPartsDto[])serializer.Deserialize(new StringReader(inputXml));

            var FilteredParts = deserializedParts.ToList().Where(p => p.SupplierId <= context.Suppliers.Count());

            var mappedParts = InitializeMapper().Map<IEnumerable<Part>>(FilteredParts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}";

        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = GetSerializer("Cars", typeof(ImportCarDto[]));

            var deserializedCars = (ImportCarDto[])serializer.Deserialize(new StringReader(inputXml));

            var carsToImport = new HashSet<Car>();
            var partCarsToImport = new HashSet<PartCar>();

            foreach (var car in deserializedCars)
            {
                var c = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                carsToImport.Add(c);

                foreach (var part in car.PartIds.Select(x => x.Id).Distinct())
                {
                    if (part > context.Parts.Count())
                    {
                        continue;
                    }
                    partCarsToImport.Add(new PartCar
                    {
                        PartId = part,
                        Car = c
                    });
                }
            }

            context.Cars.AddRange(carsToImport);
            context.PartCars.AddRange(partCarsToImport);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count}";
        }

        public static XmlSerializer GetSerializer(string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }


        public static IMapper InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}