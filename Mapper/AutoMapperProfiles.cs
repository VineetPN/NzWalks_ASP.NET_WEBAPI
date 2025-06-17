using AutoMapper;
using MyApiProjectTest.Models.Domain;
using MyApiProjectTest.Models.Domain.DTOs;
using MyAPIProjectTest.Models.DTOs;

namespace MyAPIProjectTest.Mapper{
    public class AutoMapperProfiles : Profile{
        public AutoMapperProfiles(){
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, AddRegionRequestDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDTO>().ReverseMap();
        }
    }
}