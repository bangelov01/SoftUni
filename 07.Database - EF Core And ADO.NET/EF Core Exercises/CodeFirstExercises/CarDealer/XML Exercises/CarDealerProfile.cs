using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSuppliersDto, Supplier>();
            CreateMap<ImportPartsDto, Part>();

            CreateMap<ImportCustomersDto, Customer>()
                .ForMember(c => c.BirthDate, opt => opt.MapFrom(src => DateTime.Parse(src.BirthDate)))
                .ForMember(c => c.IsYoungDriver, opt => opt.MapFrom(src => bool.Parse(src.IsYoungDriver)));

            CreateMap<Car, ExportCarWithDistanceDto>();
            CreateMap<Car, ExportCarByMakeBMWDto>();
        }
    }
}
