using AutoMapper;
using JobTrackerAPI.Model.Entities;
using JobTrackerAPI.Repository.Entities;

namespace JobTrackerAPI.Repository.MappingProfiles
{
    public class JobEntityProfile : Profile
    {
        public JobEntityProfile() { 
            CreateMap<JobEntity, Job>().ReverseMap();
        }
    }
}
