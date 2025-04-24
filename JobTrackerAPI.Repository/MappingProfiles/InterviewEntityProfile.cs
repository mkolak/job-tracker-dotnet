using AutoMapper;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Entities;

namespace JobTrackerAPI.Repository.MappingProfiles
{
    public class InterviewEntityProfile : Profile
    {
        public InterviewEntityProfile()
        {
            CreateMap<InterviewEntity, Interview>().ReverseMap();
        }
    }
}
