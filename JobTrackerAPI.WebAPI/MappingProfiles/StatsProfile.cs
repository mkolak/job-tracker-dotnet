using AutoMapper;
using JobTrackerAPI.Model.DTOs;
using JobTrackerAPI.WebAPI.Entities;

namespace JobTrackerAPI.WebAPI.MappingProfiles
{
    public class StatsProfile : Profile
    {
        public StatsProfile()
        {
            CreateMap<LocationCountDto, LocationStatsResponseDto>()
                .ForMember(dest => dest._id, opt => opt.MapFrom(src => src.Location));

            CreateMap<StatusCountDto, StatusStatsResponseDto>()
                .ForMember(dest => dest._id, opt => opt.MapFrom(src => src.Status));

            CreateMap<MonthlyStatusStatsDto, MonthlyStatsResponseDto>();
        }
    }
}