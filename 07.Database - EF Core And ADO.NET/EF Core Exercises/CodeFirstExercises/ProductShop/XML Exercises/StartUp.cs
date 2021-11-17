using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;

using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Export.SoldProductDtos;

using AutoMapper;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //var inputFromXmlUser = File.ReadAllText("Datasets/users.xml");
            //var inputFromXmlProduct = File.ReadAllText("Datasets/products.xml");
            //var inputFromXmlCategory = File.ReadAllText("Datasets/categories.xml");
            var inputFromXmlCategoryProduct = File.ReadAllText("Datasets/categories-products.xml");

            //Console.WriteLine(ImportUsers(context, inputFromXmlUser));
            //Console.WriteLine(ImportProducts(context, inputFromXmlProduct));
            //Console.WriteLine(ImportCategories(context, inputFromXmlCategory));
            //Console.WriteLine(ImportCategoryProducts(context, inputFromXmlCategoryProduct));
            //Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = GetSerializer("Users", typeof(ImportUserDto[]));

            var deserializedUsers = (ImportUserDto[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = InitializeMapper();

            var mappedUsers = mapper.Map<IEnumerable<User>>(deserializedUsers);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = GetSerializer("Products", typeof(ImportProductDto[]));

            var deserializedProducts = (ImportProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var mapper = InitializeMapper();

            var mappedProducts = mapper.Map<IEnumerable<Product>>(deserializedProducts);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = GetSerializer("Categories", typeof(ImportCategoryDto[]));

            var deserializedCategories = (ImportCategoryDto[])serializer.Deserialize(new StringReader(inputXml));

            var filteredCategories = new HashSet<ImportCategoryDto>();

            foreach (var c in deserializedCategories)
            {
                if (string.IsNullOrEmpty(c.Name))
                {
                    continue;
                }

                filteredCategories.Add(c);
            }

            var mapper = InitializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(filteredCategories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = GetSerializer("CategoryProducts", typeof(ImportCategoryProductDto[]));

            var deserializedCategoryProduct = (ImportCategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var filteredCategoryProducts = new HashSet<ImportCategoryProductDto>();

            foreach (var cp in deserializedCategoryProduct)
            {
                if (cp.CategoryId > context.Categories.Count()
                    || cp.ProductId > context.Products.Count())
                {
                    continue;
                }

                filteredCategoryProducts.Add(cp);
            }

            var mapper = InitializeMapper();

            var mappedCategoryProducts = mapper.Map<IEnumerable<CategoryProduct>>(filteredCategoryProducts);

            context.CategoryProducts.AddRange(mappedCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedCategoryProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToArray();

            var serializer = GetSerializer("Products", typeof(ExportProductInRangeDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, productsInRange, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(u => u.ProductsSold.Count > 1)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserSoldProductDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Select(ps => new ProductDto
                    {
                        Name = ps.Name,
                        Price = ps.Price.ToString()
                    }).ToArray()
                }).ToArray();

            var serializer = GetSerializer("Users", typeof(ExportUserSoldProductDto[]));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var sb = new StringBuilder();

            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, soldProducts, namespaces);
            }

            return sb.ToString().TrimEnd();

        }

        public static XmlSerializer GetSerializer (string root, Type dtoType)
        {
            return new XmlSerializer(dtoType, new XmlRootAttribute(root));
        }

        public static IMapper InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            return mapperConfig.CreateMapper();
        }
    }
}