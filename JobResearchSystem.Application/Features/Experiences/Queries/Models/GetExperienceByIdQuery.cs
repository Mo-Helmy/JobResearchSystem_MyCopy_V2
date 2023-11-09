using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Experiences.Queries.Models
{
    public class GetExperienceByIdQuery : IRequest<BaseResponse<ExperienceResponse>>
    {
        public int ExperienceId { get; set; }
    }
}
