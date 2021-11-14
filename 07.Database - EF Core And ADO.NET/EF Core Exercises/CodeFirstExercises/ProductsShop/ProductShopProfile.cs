using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Input;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDto, User>();
            CreateMap<ProductInputDto, Product>();
            CreateMap<CategoryInputDto, Category>();
            CreateMap<CategoryProductInputDto, CategoryProduct>();
            CreateMap<Product, ProductExportDto>()
                .ForMember(x => x.Seller, opt => opt.MapFrom(src => $"{src.Seller.FirstName} {src.Seller.LastName}"));
            CreateMap<Category, CategoryByProductExportDto>()
                .ForMember(x => x.Category, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.AveragePrice, opt => opt.MapFrom(src => $"{src.CategoryProducts.Average(x => x.Product.Price):f2}"))
                .ForMember(x => x.ProductsCount, opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(x => x.TotalRevenue, opt => opt.MapFrom(src => $"{src.CategoryProducts.Sum(p => p.Product.Price):f2}"));
        }
    }
}
