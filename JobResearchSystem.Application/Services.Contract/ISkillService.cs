using JobResearchSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Application.Services.Contract
{
    public interface ISkillService : IGenericService<Skill>
    {
        Task<IEnumerable<Skill>> AddSkillRangeToJobSeeker(int jobSeekerId, IEnumerable<Skill> skills);
    }
}
