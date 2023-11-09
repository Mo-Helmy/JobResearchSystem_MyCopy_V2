using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Queries.Models
{
    public class GetAllSkillsQuery : IRequest<BaseResponse<IReadOnlyList<SkillResponse>>>
    {
    }
}
