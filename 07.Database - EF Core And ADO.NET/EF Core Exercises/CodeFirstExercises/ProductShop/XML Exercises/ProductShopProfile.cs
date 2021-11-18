using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //import
            CreateMap<ImportProductDto, Product>();
            CreateMap<ImportUserDto, User>();
            CreateMap<ImportCategoryDto, Category>();
            CreateMap<ImportCategoryProductDto, CategoryProduct>();

            //export
            CreateMap<Category, ExportCategoryByProductDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(x => x.AveragePrice, opt => opt.MapFrom(src => src.CategoryProducts.Average(x => x.Product.Price)))
                .ForMember(x => x.ProductsCount, opt => opt.MapFrom(src => src.CategoryProducts.Count))
                .ForMember(x => x.TotalRevenue, opt => opt.MapFrom(src => src.CategoryProducts.Sum(p => p.Product.Price)));
        }
    }
}
