using JobResearchSystem.Application.Features.JobSeekers.Queries.Response;
using JobResearchSystem.Application.Responses;
using MediatR;

namespace JobResearchSystem.Application.Features.JobSeekers.Queries.Models
{
    public class GetAllJobSeekersQuery : IRequest<PaginationResponse<JobSeekerResponse>>
    {
        private const int maxPageSize = 10;
        private int pageSize = 5;
        private string? search;

        public int PageSize { get => pageSize; set => pageSize = value > maxPageSize ? maxPageSize : value; }
        public int PageIndex { get; set; } = 1;
        public string? Search { get; set; }
    }
}
