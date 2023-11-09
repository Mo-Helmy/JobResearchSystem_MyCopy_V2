using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobResearchSystem.Application.Features.JobSeekers.Commands.Models
{
    public class AddJobSeekerCommand : IRequest<BaseResponse<JobSeekerResponse>>
    {
        public string UserId { get; set; }

        public IFormFile ImageForm { get; set; }
        public IFormFile CvForm { get; set; }
    }
}
