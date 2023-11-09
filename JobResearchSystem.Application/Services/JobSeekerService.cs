using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Application.Specifications.JobSeekerSpecifications;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Specifications;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;

namespace JobResearchSystem.Application.Services
{
    public class JobSeekerService : GenericService<JobSeeker>, IJobSeekerService
    {
        public JobSeekerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IReadOnlyList<JobSeeker>> GetAllJobSeekerPaginationAsync(GetAllJobSeekersQuery query)
        {
            var jobSeekerSpecification = new JobSeekerSpecifications(query);

            var entityList = await _unitOfWork.GetRepository<JobSeeker>().GetAllWithSpecAsync(jobSeekerSpecification);

            return entityList;
        }

        public async Task<int> GetAllJobSeekerPaginationCountAsync(GetAllJobSeekersQuery query)
        {
            var jobSeekerSpecification = new JobSeekerCountSpecifications(query);

            var totalCount = await _unitOfWork.GetRepository<JobSeeker>().GetCountWithSpecAsync(jobSeekerSpecification);

            return totalCount;
        }

        public override async Task<JobSeeker?> GetByIdAsync(int id)
        {
            var jobSeekerSpec = new BaseSpecification<JobSeeker>(x => x.Id == id) 
            {
                Includes = new List<System.Linq.Expressions.Expression<Func<JobSeeker, object>>> ()
                {
                    x => x.User,
                    x => x.Skills,
                    x => x.Experiences,
                    x => x.Qualifications,
                }
            };

            var entity = await _unitOfWork.GetRepository<JobSeeker>().GetByIdWithSpecAsync(jobSeekerSpec);

            return entity;
        }
    }
}
