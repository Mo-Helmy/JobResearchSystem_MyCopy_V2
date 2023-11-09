using AutoMapper;
using JobResearchSystem.Application.Features.Skills.Commands.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Domain.Entities;

namespace JobResearchSystem.Application.Mapping.Skills
{
    public class SkillsMappingProfile : Profile
    {
        public SkillsMappingProfile()
        {
            CreateMap<Skill, SkillResponse>();
            CreateMap<Skill, SkillDetailsResponse>();

            CreateMap<UpdateSkillCommand, Skill>();

            CreateMap<AddSkillCommand, Skill>();
            //CreateMap<AddSkillRangeCommand, Skill>().ReverseMap();

            CreateMap<UpdateSkillCommand, Skill>();
        }
    }
}
