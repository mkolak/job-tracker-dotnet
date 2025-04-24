using AutoMapper;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.WebAPI.Entities;

namespace JobTrackerAPI.WebAPI.MappingProfiles
{
    public class JobProfile : Profile
    {
        public JobProfile() {
            CreateMap<Job, JobResponseDto>()
                .ForMember(dest => dest._id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Interviews, opt => opt.MapFrom(src => src.Interviews));

            CreateMap<JobRequestDto, Job>()
                .ForMember(dest => dest.AppliedAt, opt => opt.MapFrom(src => src.AppliedAt ?? DateTime.UtcNow))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) 
                .ForMember(dest => dest.Id, opt => opt.Ignore())        
                .ForMember(dest => dest.Interviews, opt => opt.Ignore());
        }
    }
}
