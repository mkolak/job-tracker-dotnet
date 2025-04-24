using AutoMapper;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.WebAPI.Entities;

namespace JobTrackerAPI.WebAPI.MappingProfiles
{
    public class InterviewProfile : Profile
    {
        public InterviewProfile()
        {
            CreateMap<Interview, InterviewResponseDto>()
                .ForMember(dest => dest._id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Advertiser, opt => opt.MapFrom(src => src.Job.Advertiser));

            CreateMap<InterviewRequestDto, Interview>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Job, opt => opt.Ignore());
        }
    }
}
