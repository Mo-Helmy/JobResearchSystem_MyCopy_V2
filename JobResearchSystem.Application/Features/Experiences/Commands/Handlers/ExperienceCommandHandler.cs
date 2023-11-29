using AutoMapper;
using JobResearchSystem.Application.Features.Experiences.Commands.Models;
using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using MediatR;

namespace JobResearchSystem.Application.Features.Experiences.Commands.Handlers
{
    public class ExperienceCommandHandler : ResponseHandler,
                                       IRequestHandler<AddExperienceCommand, BaseResponse<ExperienceResponse>>,
                                       IRequestHandler<DeleteExperienceCommand, BaseResponse<string>>,
                                       IRequestHandler<UpdateExperienceCommand, BaseResponse<ExperienceResponse>>
    {
        #region CTOR
        private IExperienceService _experienceService;
        private IMapper _mapper;

        public ExperienceCommandHandler(IExperienceService ExperienceSerice, IMapper mapper)
        {
            _experienceService = ExperienceSerice;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<ExperienceResponse>> Handle(AddExperienceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Experience>(request);

            var createdEntity = await _experienceService.CreateAsync(entity);

            if (createdEntity is null)
                return BadRequest<ExperienceResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<ExperienceResponse>(createdEntity);

            return Created(mappedEntity);
        }

        public async Task<BaseResponse<ExperienceResponse>> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Experience>(request);

            var updatedEntity = await _experienceService.UpdateAsync(request.Id, request);

            if (updatedEntity is null)
                return BadRequest<ExperienceResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<ExperienceResponse>(updatedEntity);

            return Success<ExperienceResponse>(mappedEntity);
        }


        public async Task<BaseResponse<string>> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
        {
            var result = await _experienceService.DeleteAsync(request.ExperienceId);

            if (!result)
                return BadRequest<string>("");

            return Deleted<string>("");
        }

    }
}
