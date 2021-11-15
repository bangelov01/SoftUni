using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;

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
        }
    }
}
