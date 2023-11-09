using AutoMapper;
using ECommerce.Api.Helpers;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Specifications.JobSeekerSpecifications;
using JobResearchSystem.Domain.Entities;

namespace JobResearchSystem.Application.Mapping.JobSeekers
{
    public class JobSeekersMappingProfile : Profile
    {
        public JobSeekersMappingProfile()
        {
            CreateMap<JobSeeker, JobSeekerResponse>()
                .ForMember(x => x.FirstName, o => o.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, o => o.MapFrom(x => x.User.LastName))
                .ForMember(x => x.CVFilePath, o => o.MapFrom<JobSeekerImagesUrlResolver>())
                .ForMember(x => x.ImageFilePath, o => o.MapFrom<JobSeekerCvsUrlResolver>());
            
            CreateMap<JobSeeker, JobSeekerDetailsResponse>()
                .ForMember(x => x.FirstName, o => o.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.LastName, o => o.MapFrom(x => x.User.LastName))
                .ForMember(x => x.CVFilePath, o => o.MapFrom<JobSeekerImagesUrlResolver>())
                .ForMember(x => x.ImageFilePath, o => o.MapFrom<JobSeekerCvsUrlResolver>());




            CreateMap<AddJobSeekerCommand, JobSeeker>();

            CreateMap<UpdateJobSeekerCommand, JobSeeker>();

            CreateMap<DeleteJobSeekerCommand, JobSeeker>();
        }
    }
}
