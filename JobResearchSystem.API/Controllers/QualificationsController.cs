using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JobResearchSystem.API.Controllers
{

    public class QualificationsController : ApiBaseController
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IReadOnlyList<QualificationResponse>>>> GetAsync()
        {
            var result = await Mediator.Send(new GetAllQualificationsQuery());

            return BaseResult(result);
        }

        [HttpGet("{QualificationId}")]
        public async Task<ActionResult<BaseResponse<QualificationResponse>>> Get([FromRoute] GetQualificationByIdQuery getByIdQuery)
        {
            var result = await Mediator.Send(getByIdQuery);

            return BaseResult(result);
        }

        [HttpGet("jobseeker/{JobSeekerId}")]
        public async Task<ActionResult<BaseResponse<QualificationResponse>>> GetByJobSeekerId([FromRoute] GetAllQualificationsByJobSeekerIdQuery getByJobSeekerIdQuery)
        {
            var result = await Mediator.Send(getByJobSeekerIdQuery);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpPost]
        public async Task<ActionResult<BaseResponse<QualificationResponse>>> Post([FromBody] AddQualificationCommand addCommand)
        {
            var result = await Mediator.Send(addCommand);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpPut()]
        public async Task<ActionResult<BaseResponse<QualificationResponse>>> Put([FromBody] UpdateQualificationCommand updateCommand)
        {
            var result = await Mediator.Send(updateCommand);

            return BaseResult(result);
        }

        // TODO Authorize to jobSeeker only
        [HttpDelete()]
        public async Task<ActionResult<BaseResponse<string>>> Delete([FromBody] DeleteQualificationCommand deleteCommand)
        {
            var result = await Mediator.Send(deleteCommand);

            return BaseResult(result);
        }
    }
}
