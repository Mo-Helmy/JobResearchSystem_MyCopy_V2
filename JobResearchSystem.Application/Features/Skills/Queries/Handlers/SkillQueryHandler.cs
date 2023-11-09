using AutoMapper;
using JobResearchSystem.Application.Features.Skills.Queries.Models;
using JobResearchSystem.Application.Features.Skills.Queries.Responses;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using MediatR;

namespace JobResearchSystem.Application.Features.Skills.Queries.Handlers
{
    public class SkillQueryHandler : ResponseHandler,
                                     IRequestHandler<GetAllSkillsQuery, BaseResponse<IReadOnlyList<SkillResponse>>>,
                                     IRequestHandler<GetSkillByIdQuery, BaseResponse<SkillDetailsResponse>>
    {
        private readonly IGenericService<Skill> _skillService;
        private readonly IMapper _mapper;

        public SkillQueryHandler(IGenericService<Skill> skillService, IMapper mapper)
        {
            this._skillService = skillService;
            this._mapper = mapper;
        }

        public async Task<BaseResponse<IReadOnlyList<SkillResponse>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var entityList = await _skillService.GetAllAsync();

            var mappedList = _mapper.Map<IReadOnlyList<SkillResponse>>(entityList);

            return Success(mappedList, new { mappedList.Count });
        }

        public async Task<BaseResponse<SkillDetailsResponse>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _skillService.GetByIdAsync(request.Id);

            if (entity is null) return NotFound<SkillDetailsResponse>();

            var mappedEntity = _mapper.Map<SkillDetailsResponse>(entity);

            return Success(mappedEntity);
        }
    }
}
