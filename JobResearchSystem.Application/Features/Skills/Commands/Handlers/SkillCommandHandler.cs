using AutoMapper;
using JobResearchSystem.Application.Features.Skills.Commands.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Repositories.Contract;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JobResearchSystem.Application.Features.Skills.Commands.Handlers
{
    public class SkillCommandHandler : ResponseHandler,
                                       IRequestHandler<AddSkillCommand, BaseResponse<SkillDetailsResponse>>,
                                       IRequestHandler<AddSkillRangeCommand, BaseResponse<string>>,
                                       IRequestHandler<DeleteSkillCommand, BaseResponse<string>>,
                                       IRequestHandler<UpdateSkillCommand, BaseResponse<SkillDetailsResponse>>
    {
        #region CTOR
        private ISkillService _skillService;
        private IMapper _mapper;

        public SkillCommandHandler(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<SkillDetailsResponse>> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Skill>(request);

            var createdEntity = await _skillService.CreateAsync(entity);

            if (createdEntity is null)
                return BadRequest<SkillDetailsResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<SkillDetailsResponse>(createdEntity);

            if (mappedEntity is null) return BadRequest<SkillDetailsResponse>("");

            return Created(mappedEntity);
        }

        public async Task<BaseResponse<SkillDetailsResponse>> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Skill>(request);

            var updatedEntity = await _skillService.UpdateAsync(request.Id, request);

            if (updatedEntity is null)
                return BadRequest<SkillDetailsResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<SkillDetailsResponse>(updatedEntity);

            if (mappedEntity is null)  return BadRequest<SkillDetailsResponse>("");

             return Success(mappedEntity); 
        }

        public async Task<BaseResponse<string>> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var result = await _skillService.DeleteAsync(request.SkillId);

            if (!result) return BadRequest<string>("");

            return Deleted<string>("");
        }

        public async Task<BaseResponse<string>> Handle(AddSkillRangeCommand request, CancellationToken cancellationToken)
        {
            var skillList = _mapper.Map<IEnumerable<Skill>>(request.Skills);

            if (!skillList.Any()) throw new ValidationException("skills can't be empty");

            var addedSkills = await _skillService.AddSkillRangeToJobSeeker(request.JobSeekerId, skillList);

            return Created<string>("Skills added successfully.");
        }
    }
}
