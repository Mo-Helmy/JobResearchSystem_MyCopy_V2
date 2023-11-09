using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using JobResearchSystem.Application.Specifications.JobSeekerSpecifications;
using JobResearchSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Application.Services.Contract
{
    public interface IJobSeekerService : IGenericService<JobSeeker>
    {
        Task<IReadOnlyList<JobSeeker>> GetAllJobSeekerPaginationAsync(GetAllJobSeekersQuery query);
        Task<int> GetAllJobSeekerPaginationCountAsync(GetAllJobSeekersQuery query);
    }
}
