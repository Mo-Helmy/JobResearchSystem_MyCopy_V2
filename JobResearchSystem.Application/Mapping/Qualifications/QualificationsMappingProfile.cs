using AutoMapper;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Domain.Entities;

namespace JobResearchSystem.Application.Mapping.Qualifications
{
    public class QualificationsMappingProfile : Profile
    {
        public QualificationsMappingProfile()
        {
            CreateMap<Qualification, QualificationResponse>();

            CreateMap<AddQualificationCommand, Qualification>();

            CreateMap<UpdateQualificationCommand, Qualification>();

            CreateMap<DeleteQualificationCommand, Qualification>();
        }
    }
}
