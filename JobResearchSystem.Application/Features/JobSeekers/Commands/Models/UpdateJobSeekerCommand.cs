using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobResearchSystem.Application.Features.JobSeekers.Commands.Models
{
    public class UpdateJobSeekerCommand : IRequest<BaseResponse<JobSeekerResponse>>
    {
        public int Id { get; set; }

        public IFormFile? ImageForm { get; set; }
        public IFormFile? CvForm { get; set; }
    }
}
