using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Experiences.Queries.Models
{
    public class GetAllExperiencesByJobSeekerIdQuery : IRequest<BaseResponse<IReadOnlyList<ExperienceResponse>>>
    {
        public int JobSeekerId { get; set; }
    }
}
