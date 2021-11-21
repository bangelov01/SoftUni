using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

using Microsoft.EntityFrameworkCore;

using CarDealer.Data;
using CarDealer.DTO.Import;
using CarDealer.Models;
using CarDealer.DTO.Import.ImportCarsDtos;
using CarDealer.DTO.Export;
using CarDealer.DTO.Export.ExportCarsWithPartsDtos;
using CarDealer.DTO.Export.ExportSalesWithDiscountDtos;

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
            var salesFromXml = File.ReadAllText("Datasets/sales.xml");

            Console.WriteLine(ImportSuppliers(context, suppliersFromXml));
            Console.WriteLine(ImportParts(context, partsFromXml));
            Console.WriteLine(ImportCars(context, carsFromXml));
            Console.WriteLine(ImportCustomers(context, customersFromXml));
            Console.WriteLine(ImportSales(context, salesFromXml));
            Console.WriteLine(GetCarsWithDistance(context));
            Console.WriteLine(GetCarsFromMakeBmw(context));
            Console.WriteLine(GetLocalSuppliers(context));
            Console.WriteLine(GetCarsWithTheirListOfParts(context));
            Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = GetSerializer("Sales", typeof(ImportSaleDto[]));

            var deserializedSales = (ImportSaleDto[])serializer.Deserialize(new StringReader(inputXml));

            var filteredSales = deserializedSales.ToList().Where(s => s.CarId <= context.Cars.Count());

            var mappedSales = InitializeMapper().Map<IEnumerable<Sale>>(filteredSales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}";

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

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSuppliersDto>(InitializeMapper().ConfigurationProvider)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("suppliers", typeof(ExportLocalSuppliersDto[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, localSuppliers, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Include(c => c.PartCars)
                .Select(c => new ExportCarsWithPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new PartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(pc => pc.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .Take(5)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("cars", typeof(ExportCarsWithPartsDto[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, carsWithParts, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var salesByCustomer = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .ProjectTo<ExportSalesByCustomerDto>(InitializeMapper().ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("customers", typeof(ExportSalesByCustomerDto[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, salesByCustomer, namespaces);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Include(c => c.Car)
                .Select(s => new ExportSaleWithDiscountDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price)
                }).ToArray();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = GetSerializer("sales", typeof(ExportSaleWithDiscountDto[]));

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, salesWithDiscount, namespaces);
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