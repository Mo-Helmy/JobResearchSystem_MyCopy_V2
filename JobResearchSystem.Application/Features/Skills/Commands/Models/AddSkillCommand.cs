using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Commands.Models
{
    public class AddSkillCommand : IRequest<BaseResponse<SkillDetailsResponse>>
    {
        public string SkillName { get; set; }
    }
}
