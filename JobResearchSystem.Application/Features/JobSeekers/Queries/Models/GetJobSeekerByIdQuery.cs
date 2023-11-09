using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.JobSeekers.Queries.Models
{
    public class GetJobSeekerByIdQuery : IRequest<BaseResponse<JobSeekerDetailsResponse>>
    {
        public int JobSeekerId { get; set; }
    }
}
