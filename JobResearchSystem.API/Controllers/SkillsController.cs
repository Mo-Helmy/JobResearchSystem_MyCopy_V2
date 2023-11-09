using JobResearchSystem.Application.Features.Skills.Commands.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JobResearchSystem.API.Controllers
{

    public class SkillsController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IReadOnlyList<SkillResponse>>>> GetAsync()
        {
            var result = await Mediator.Send(new GetAllSkillsQuery());

            return BaseResult(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BaseResponse<SkillResponse>>> Get([FromRoute] GetSkillByIdQuery getByIdQuery)
        {
            var result = await Mediator.Send(getByIdQuery);

            return BaseResult(result);
        }

        // TODO Authorize to admin only
        [HttpPost]
        public async Task<ActionResult<BaseResponse<SkillDetailsResponse>>> Post([FromBody] AddSkillCommand addCommand)
        {
            var result = await Mediator.Send(addCommand);

            return BaseResult(result);
        }

        // TODO Authorize to admin and jobSeeker
        [HttpPost("AddRangeToJobSeeker")]
        public async Task<ActionResult<BaseResponse<SkillDetailsResponse>>> Put(AddSkillRangeCommand addSkillRangeCommand)
        {
            var result = await Mediator.Send(addSkillRangeCommand);

            return BaseResult(result);
        }

        // TODO Authorize to admin only
        [HttpPut()]
        public async Task<ActionResult<BaseResponse<SkillDetailsResponse>>> Put([FromBody] UpdateSkillCommand updateCommand)
        {
            var result = await Mediator.Send(updateCommand);

            return BaseResult(result);
        }

        // TODO Authorize to admin only
        [HttpDelete()]
        public async Task<ActionResult<BaseResponse<string>>> Delete([FromBody] DeleteSkillCommand deleteCommand)
        {
            var result = await Mediator.Send(deleteCommand);

            return BaseResult(result);
        }
    }
}
