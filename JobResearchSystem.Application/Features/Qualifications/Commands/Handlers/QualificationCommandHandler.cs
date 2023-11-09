using AutoMapper;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Queries.Response;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using MediatR;

namespace JobResearchSystem.Application.Features.Qualifications.Commands.Handlers
{
    public class QualificationCommandHandler : ResponseHandler,
                                       IRequestHandler<AddQualificationCommand, BaseResponse<QualificationResponse>>,
                                       IRequestHandler<DeleteQualificationCommand, BaseResponse<string>>,
                                       IRequestHandler<UpdateQualificationCommand, BaseResponse<QualificationResponse>>
    {
        #region CTOR
        private IQualificationService _qualificationService;
        private IMapper _mapper;

        public QualificationCommandHandler(IQualificationService QualificationService, IMapper mapper)
        {
            _qualificationService = QualificationService;
            _mapper = mapper;
        }
        #endregion

        public async Task<BaseResponse<QualificationResponse>> Handle(AddQualificationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Qualification>(request);

            var createdEntity = await _qualificationService.CreateAsync(entity);

            if (createdEntity is null)
                return BadRequest<QualificationResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<QualificationResponse>(createdEntity);

            return Created(mappedEntity);
        }

        public async Task<BaseResponse<QualificationResponse>> Handle(UpdateQualificationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Qualification>(request);

            var updatedEntity = await _qualificationService.UpdateAsync(entity);

            if (updatedEntity is null)
                return BadRequest<QualificationResponse>("Something Went Wrong");

            var mappedEntity = _mapper.Map<QualificationResponse>(updatedEntity);

            return Success(mappedEntity);
        }


        public async Task<BaseResponse<string>> Handle(DeleteQualificationCommand request, CancellationToken cancellationToken)
        {
            var result = await _qualificationService.DeleteAsync(request.QualificationId);

            if (!result)
                return BadRequest<string>("");

            return Deleted<string>("");
        }

    }
}
