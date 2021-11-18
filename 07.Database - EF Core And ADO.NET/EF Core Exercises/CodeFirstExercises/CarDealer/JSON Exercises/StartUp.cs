using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Export.CarsWithListOfPartsDtos;
using CarDealer.DTO.Import;
using CarDealer.Models;
using CarDealer.DTO.Export.SalesWithDiscountDtos;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Change variables for other methods etc...

            //var suppliesJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var carsJson = File.ReadAllText("../../../Datasets/cars.json");
            //var customersJson = File.ReadAllText("../../../Datasets/customers.json");
            //var salessJson = File.ReadAllText("../../../Datasets/sales.json");

            //Console.WriteLine(ImportSuppliers(context, suppliesJson));
            //Console.WriteLine(ImportParts(context, partsJson));
            //Console.WriteLine(ImportCars(context, carsJson));
            //Console.WriteLine(ImportCustomers(context, customersJson));
            //Console.WriteLine(ImportSales(context, salessJson));

            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var mapper = InitializeMapper();

            var deserializedSuppliers = JsonConvert.DeserializeObject<IEnumerable<SuppliersImportDto>>(inputJson);

            var mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(deserializedSuppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var mapper = InitializeMapper();

            var deserializedParts = JsonConvert.DeserializeObject<IEnumerable<PartsImportDto>>(inputJson).Where(x => x.SupplierId <= 31);

            var mappedParts = mapper.Map<IEnumerable<Part>>(deserializedParts);

            context.Parts.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var deserializedCars = JsonConvert.DeserializeObject<IEnumerable<CarImportDto>>(inputJson);

            var carsToImport = new List<Car>();
            var partCarsToImport = new List<PartCar>();

            foreach (var car in deserializedCars)
            {
                var newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                carsToImport.Add(newCar);

                foreach (var part in car.PartsId.Distinct())
                {
                    partCarsToImport.Add(new PartCar
                    {
                        PartId = part,
                        Car = newCar
                    });
                }
            }

            context.Cars.AddRange(carsToImport);
            context.PartCars.AddRange(partCarsToImport);
            context.SaveChanges();

            return $"Successfully imported {carsToImport.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var mapper = InitializeMapper();

            var deserializedCustomers = JsonConvert.DeserializeObject<IEnumerable<CustomersImportDto>>(inputJson);

            var mappedCustomers = mapper.Map<IEnumerable<Customer>>(deserializedCustomers);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var mapper = InitializeMapper();

            var deserializedSales = JsonConvert.DeserializeObject<IEnumerable<SalesImportDto>>(inputJson);

            var mappedSales = mapper.Map<IEnumerable<Sale>>(deserializedSales);

            context.Sales.AddRange(mappedSales);
            context.SaveChanges();

            return $"Successfully imported {mappedSales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var mapper = InitializeMapper();

            var orderedCustomers = context.Customers
                .OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver)
                .ProjectTo<OrderedCustomersExportDto>(mapper.ConfigurationProvider)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy"
            };

            return JsonConvert.SerializeObject(orderedCustomers, jsonSettings);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var mapper = InitializeMapper();

            var carsWithMakeToyota = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarsFromMakeToyotaExportDto>(mapper.ConfigurationProvider)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(carsWithMakeToyota, jsonSettings);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapper = InitializeMapper();

            var localSuppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<LocalSuppliersExportDto>(mapper.ConfigurationProvider)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(localSuppliers, jsonSettings);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Include(c => c.PartCars)
                .Select(c => new CarsWithPartsListDto
                {
                    Car = new CarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.PartCars.Select(pc => new PartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2")
                    }).ToArray()

                }).ToArray();


            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(carsWithParts, jsonSettings);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var mapper = InitializeMapper();

            var salesByCustomer = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .ProjectTo<CustomersTotalSalesDto>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(salesByCustomer, jsonSettings);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Take(10)
                .Select(s => new SaleWithDiscountDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f2"),
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                }).ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            return JsonConvert.SerializeObject(salesWithDiscount, jsonSettings);
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