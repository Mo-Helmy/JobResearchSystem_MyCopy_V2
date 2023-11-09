using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Application.Features.JobSeekers.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobResearchSystem.Infrastructure.Specifications;

namespace JobResearchSystem.Application.Specifications.JobSeekerSpecifications
{
    public class JobSeekerSpecifications : BaseSpecification<JobSeeker>
    {
        public JobSeekerSpecifications(GetAllJobSeekersQuery query)
        {
            Includes.Add(x => x.User);

            if (!string.IsNullOrEmpty(query.Search))
                CriteriaList.Add(x => x.User.FirstName.ToLower().Contains(query.Search) || x.User.LastName.ToLower().Contains(query.Search));

            ApplyPagination(query.PageSize * (query.PageIndex - 1), query.PageSize);
        }
    }
}
