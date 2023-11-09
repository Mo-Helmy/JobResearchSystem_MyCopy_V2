using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using JobResearchSystem.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;

namespace JobResearchSystem.API.Controllers
{

    public class JobSeekersController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<PaginationResponse<JobSeekerResponse>>> GetAsync([FromQuery] GetAllJobSeekersQuery jobSeekersQuery)
        {
            var result = await Mediator.Send(jobSeekersQuery);

            return PaginationResult(result);
        }

        [HttpGet("{JobSeekerId}")]
        public async Task<ActionResult<BaseResponse<JobSeekerResponse>>> Get([FromRoute] GetJobSeekerByIdQuery getByIdQuery)
        {
            var result = await Mediator.Send(getByIdQuery);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpPost]
        public async Task<ActionResult<BaseResponse<JobSeekerResponse>>> Post([FromForm] AddJobSeekerCommand addCommand)
        {
            var result = await Mediator.Send(addCommand);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpPut()]
        public async Task<ActionResult<BaseResponse<JobSeekerResponse>>> Put([FromForm] UpdateJobSeekerCommand updateCommand)
        {
            var result = await Mediator.Send(updateCommand);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpDelete()]
        public async Task<ActionResult<BaseResponse<string>>> Delete([FromBody] DeleteJobSeekerCommand deleteCommand)
        {
            var result = await Mediator.Send(deleteCommand);

            return BaseResult(result);
        }
    }
}
