using AutoMapper;
using LABTASK2.EF.Tables;
using LABTASK2.Models;

namespace LABTASK2
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<FuelLog, FuelDTO>().ReverseMap();
            CreateMap<BusModel, FuelLog>().ReverseMap();
            CreateMap<FuelLog, BusModel>().ReverseMap();
        }
    }
}
