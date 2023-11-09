using JobResearchSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Application.Services.Contract
{
    public interface IQualificationService : IGenericService<Qualification>
    {
        Task<IReadOnlyList<Qualification>> GetAllQualificationsByJobSeekerId(int jobSeekerId);
    }
}
