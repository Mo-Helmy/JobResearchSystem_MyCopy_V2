using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.JobSeekers.Commands.Models
{
    public class DeleteJobSeekerCommand : IRequest<BaseResponse<string>>
    {
        public int JobSeekerId { get; set; }
    }
}
