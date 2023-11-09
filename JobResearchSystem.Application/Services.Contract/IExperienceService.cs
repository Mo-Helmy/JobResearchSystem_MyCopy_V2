using JobResearchSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Application.Services.Contract
{
    public interface IExperienceService : IGenericService<Experience>
    {
        Task<IReadOnlyList<Experience>> GetAllExperiencesByJobSeekerId(int jobSeekerId);
    }
}
