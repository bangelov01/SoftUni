using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Import setups
            CreateMap<SuppliersImportDto, Supplier>();
            CreateMap<PartsImportDto, Part>();
            CreateMap<CustomersImportDto, Customer>();
            CreateMap<SalesImportDto, Sale>();

            //Export setups
            CreateMap<Customer, OrderedCustomersExportDto>();
            CreateMap<Car, CarsFromMakeToyotaExportDto>();
            CreateMap<Supplier, LocalSuppliersExportDto>()
                .ForMember(p => p.PartsCount, opt => opt.MapFrom(src => src.Parts.Count));
            CreateMap<Customer, CustomersTotalSalesDto>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(c => c.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                .ForMember(c => c.SpentMoney, opt => opt.MapFrom(src => src.Sales.Sum(x => x.Car.PartCars.Sum(pc => pc.Part.Price))));

        }
    }
}
