using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

using CarDealer.Data;
using CarDealer.DTO.Import;
using CarDealer.Models;
using CarDealer.DTO.Import.ImportCarsDtos;
using CarDealer.DTO.Export;

using AutoMapper;
using AutoMapper.QueryableExtensions;

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
            var customersFromXml = File.ReadAllText("Datasets/customers.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersFromXml));
            Console.WriteLine(ImportParts(context, partsFromXml));
            Console.WriteLine(ImportCars(context, carsFromXml));
            Console.WriteLine(ImportCustomers(context, customersFromXml));
            Console.WriteLine(GetCarsWithDistance(context));
            Console.WriteLine(GetCarsFromMakeBmw(context));
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

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = GetSerializer("Customers", typeof(ImportCustomersDto[]));

            var deserializedCustomers = (ImportCustomersDto[])serializer.Deserialize(new StringReader(inputXml));

            var mappedCustomers = InitializeMapper().Map<IEnumerable<Customer>>(deserializedCustomers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .ProjectTo<ExportCarWithDistanceDto>(InitializeMapper().ConfigurationProvider)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("cars", typeof(ExportCarWithDistanceDto[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, carsWithDistance, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsWithMakeBmw = context.Cars
                .Where(c => c.Make == "BMW")
                .ProjectTo<ExportCarByMakeBMWDto>(InitializeMapper().ConfigurationProvider)
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("cars", typeof(ExportCarByMakeBMWDto[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, carsWithMakeBmw, namespaces);
            }

            return sb.ToString().TrimEnd();
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