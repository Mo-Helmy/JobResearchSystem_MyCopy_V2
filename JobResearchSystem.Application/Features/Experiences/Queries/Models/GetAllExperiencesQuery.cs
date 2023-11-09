using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Experiences.Queries.Models
{
    public class GetAllExperiencesQuery : IRequest<BaseResponse<IReadOnlyList<ExperienceResponse>>>
    {
    }
}
