using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Commands.Models
{
    public class UpdateSkillCommand : IRequest<BaseResponse<SkillDetailsResponse>>
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
    }
}
