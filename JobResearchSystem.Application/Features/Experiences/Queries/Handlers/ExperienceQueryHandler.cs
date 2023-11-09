using AutoMapper;
using JobResearchSystem.Application.Features.Experiences.Queries.Models;
using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using MediatR;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Features.Qualifications.Queries.Models;

namespace JobResearchSystem.Application.Features.Experiences.Queries.Handlers
{
    public class ExperienceQueryHandler : ResponseHandler,
                                     IRequestHandler<GetAllExperiencesQuery, BaseResponse<IReadOnlyList<ExperienceResponse>>>,
                                     IRequestHandler<GetAllExperiencesByJobSeekerIdQuery, BaseResponse<IReadOnlyList<ExperienceResponse>>>,
                                     IRequestHandler<GetExperienceByIdQuery, BaseResponse<ExperienceResponse>>
    {
        #region CTOR
        private IExperienceService _experienceService;
        private IMapper _mapper;

        public ExperienceQueryHandler(IExperienceService experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<IReadOnlyList<ExperienceResponse>>> Handle(GetAllExperiencesQuery request, CancellationToken cancellationToken)
        {
            var entitiesList = await _experienceService.GetAllAsync();

            var ListMapped = _mapper.Map<IReadOnlyList<ExperienceResponse>>(entitiesList);

            return Success(ListMapped, new { ListMapped.Count });
        }

        public async Task<BaseResponse<ExperienceResponse>> Handle(GetExperienceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _experienceService.GetByIdAsync(request.ExperienceId);

            if (entity is null)
                return NotFound<ExperienceResponse>("Sorry, There is no data to display!");

            var entityMapped = _mapper.Map<ExperienceResponse>(entity);

            return Success(entityMapped);
        }

        public async Task<BaseResponse<IReadOnlyList<ExperienceResponse>>> Handle(GetAllExperiencesByJobSeekerIdQuery request, CancellationToken cancellationToken)
        {
            var entitiesList = await _experienceService.GetAllExperiencesByJobSeekerId(request.JobSeekerId);

            var ListMapped = _mapper.Map<IReadOnlyList<ExperienceResponse>>(entitiesList);

            return Success(ListMapped, new { ListMapped.Count });
        }
    }
}
