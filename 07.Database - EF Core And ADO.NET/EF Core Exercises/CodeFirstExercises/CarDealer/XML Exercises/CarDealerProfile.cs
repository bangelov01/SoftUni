using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSuppliersDto, Supplier>();
            CreateMap<ImportPartsDto, Part>();
            CreateMap<ImportSaleDto, Sale>();
            CreateMap<ImportCustomersDto, Customer>()
                .ForMember(c => c.BirthDate, opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate)))
                .ForMember(c => c.IsYoungDriver, opt => opt.MapFrom(src => bool.Parse(src.IsYoungDriver)));


            CreateMap<Car, ExportCarWithDistanceDto>();
            CreateMap<Car, ExportCarByMakeBMWDto>();
            CreateMap<Supplier, ExportLocalSuppliersDto>()
                .ForMember(s => s.PartsCount, opt => opt.MapFrom(src => src.Parts.Count));
            CreateMap<Customer, ExportSalesByCustomerDto>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(c => c.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(c => c.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(x => x.Car.PartCars.Sum(pc => pc.Part.Price))));
        }
    }
}
