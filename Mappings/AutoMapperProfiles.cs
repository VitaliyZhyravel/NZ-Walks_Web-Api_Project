using AutoMapper;
using NZ_Walks_web_api_project.Models.DTO;
using NZWalks.Models.Domain;

namespace NZ_Walks_web_api_project.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionRespondDto>().ReverseMap();
            CreateMap<RegionRequestCreateDto, Region>().ReverseMap();
            CreateMap<RegionRequestUpdateDto, Region>().ReverseMap();
        }
    }
}
