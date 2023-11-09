using AutoMapper;
using JobResearchSystem.Application.Features.Experiences.Commands.Models;
using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Domain.Entities;

namespace JobResearchSystem.Application.Mapping.Experiences
{
    public class ExperiencesMappingProfile : Profile
    {
        public ExperiencesMappingProfile()
        {
            CreateMap<Experience, ExperienceResponse>();

            CreateMap<AddExperienceCommand, Experience>();

            CreateMap<UpdateExperienceCommand, Experience>();

            CreateMap<DeleteExperienceCommand, Experience>();
        }
    }
}
