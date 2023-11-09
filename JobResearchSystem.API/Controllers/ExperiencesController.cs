using JobResearchSystem.Application.Features.Experiences.Commands.Models;
using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.Experiences.Queries.Models;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Features.Skills.Commands.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JobResearchSystem.API.Controllers
{

    public class ExperiencesController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IReadOnlyList<ExperienceResponse>>>> GetAsync()
        {
            var result = await Mediator.Send(new GetAllExperiencesQuery());

            return BaseResult(result);
        }

        [HttpGet("{ExperienceId}")]
        public async Task<ActionResult<BaseResponse<ExperienceResponse>>> Get([FromRoute] GetExperienceByIdQuery getByIdQuery)
        {
            var result = await Mediator.Send(getByIdQuery);

            return BaseResult(result);
        }

        [HttpGet("jobseeker/{JobSeekerId}")]
        public async Task<ActionResult<BaseResponse<ExperienceResponse>>> GetByJobSeekerId([FromRoute] GetAllExperiencesByJobSeekerIdQuery getByJobSeekerIdQuery)
        {
            var result = await Mediator.Send(getByJobSeekerIdQuery);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpPost]
        public async Task<ActionResult<BaseResponse<ExperienceResponse>>> Post([FromBody] AddExperienceCommand addCommand)
        {
            var result = await Mediator.Send(addCommand);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpPut()]
        public async Task<ActionResult<BaseResponse<ExperienceResponse>>> Put([FromBody] UpdateExperienceCommand updateCommand)
        {
            var result = await Mediator.Send(updateCommand);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpDelete()]
        public async Task<ActionResult<BaseResponse<string>>> Delete([FromBody] DeleteExperienceCommand deleteCommand)
        {
            var result = await Mediator.Send(deleteCommand);

            return BaseResult(result);
        }
    }
}
