using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Queries.Models
{
    public class GetSkillByIdQuery : IRequest<BaseResponse<SkillDetailsResponse>>
    {
        public int Id { get; set; }
    }
}
