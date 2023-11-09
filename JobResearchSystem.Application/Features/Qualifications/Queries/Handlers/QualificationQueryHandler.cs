using AutoMapper;
using JobResearchSystem.Application.Features.Experiences.Queries.Models;
using JobResearchSystem.Application.Features.Experiences.Queries.BaseResponse;
using MediatR;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Features.Qualifications.Queries.Models;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;

namespace JobResearchSystem.Application.Features.Qualifications.Queries.Handlers
{
    public class QualificationQueryHandler : ResponseHandler,
                                     IRequestHandler<GetAllQualificationsQuery, BaseResponse<IReadOnlyList<QualificationResponse>>>,
                                     IRequestHandler<GetAllQualificationsByJobSeekerIdQuery, BaseResponse<IReadOnlyList<QualificationResponse>>>,
                                     IRequestHandler<GetQualificationByIdQuery, BaseResponse<QualificationResponse>>
    {
        #region CTOR
        private IQualificationService _qualificationService;
        private IMapper _mapper;

        public QualificationQueryHandler(IQualificationService qualificationService, IMapper mapper)
        {
            _qualificationService = qualificationService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<IReadOnlyList<QualificationResponse>>> Handle(GetAllQualificationsQuery request, CancellationToken cancellationToken)
        {
            var entitiesList = await _qualificationService.GetAllAsync();

            var ListMapped = _mapper.Map<IReadOnlyList<QualificationResponse>>(entitiesList);

            return Success(ListMapped, new { ListMapped.Count });
        }

        public async Task<BaseResponse<QualificationResponse>> Handle(GetQualificationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _qualificationService.GetByIdAsync(request.QualificationId);

            if (entity is null)
                return NotFound<QualificationResponse>("Sorry, There is no data to display!");

            var entityMapped = _mapper.Map<QualificationResponse>(entity);

            return Success(entityMapped);
        }

        public async Task<BaseResponse<IReadOnlyList<QualificationResponse>>> Handle(GetAllQualificationsByJobSeekerIdQuery request, CancellationToken cancellationToken)
        {
            var entitiesList = await _qualificationService.GetAllQualificationsByJobSeekerId(request.JobSeekerId);

            var ListMapped = _mapper.Map<IReadOnlyList<QualificationResponse>>(entitiesList);

            return Success(ListMapped, new { ListMapped.Count });
        }
    }
}
