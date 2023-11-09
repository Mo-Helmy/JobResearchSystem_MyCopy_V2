using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.Qualifications.Queries.Models
{
    public class GetAllQualificationsByJobSeekerIdQuery : IRequest<BaseResponse<IReadOnlyList<QualificationResponse>>>
    {
        public int JobSeekerId { get; set; }
    }
}
