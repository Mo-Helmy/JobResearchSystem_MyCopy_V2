using AutoMapper;
using MediatR;
using JobResearchSystem.Application.Responses;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using JobResearchSystem.Application.Specifications.JobSeekerSpecifications;

namespace JobResearchSystem.Application.Features.JobSeekers.Queries.Handlers
{
    public class JobSeekerQueryHandler : ResponseHandler,
                                     IRequestHandler<GetAllJobSeekersQuery, PaginationResponse<JobSeekerResponse>>,
                                     IRequestHandler<GetJobSeekerByIdQuery, BaseResponse<JobSeekerDetailsResponse>>
    {
        #region CTOR
        private IJobSeekerService _jobSeekerService;
        private IMapper _mapper;

        public JobSeekerQueryHandler(IJobSeekerService jobSeekerService, IMapper mapper)
        {
            _jobSeekerService = jobSeekerService;
            _mapper = mapper;
        }
        #endregion

        public async Task<PaginationResponse<JobSeekerResponse>> Handle(GetAllJobSeekersQuery request, CancellationToken cancellationToken)
        {
            var entitiesList = await _jobSeekerService.GetAllJobSeekerPaginationAsync(request);

            var listMapped = _mapper.Map<IReadOnlyList<JobSeekerResponse>>(entitiesList);

            var totalCount = await _jobSeekerService.GetAllJobSeekerPaginationCountAsync(request);

            return PaginateSuccess(request.PageIndex, request.PageSize, totalCount, listMapped);
        }

        public async Task<BaseResponse<JobSeekerDetailsResponse>> Handle(GetJobSeekerByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _jobSeekerService.GetByIdAsync(request.JobSeekerId);

            if (entity is null)
                return NotFound<JobSeekerDetailsResponse>("Sorry, There is no data to display!");

            var entityMapped = _mapper.Map<JobSeekerDetailsResponse>(entity);

            return Success(entityMapped);
        }

    }
}
