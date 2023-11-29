using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Specifications;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Application.Services
{
    public class QualificationService : GenericService<Qualification>, IQualificationService
    {
        public QualificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IReadOnlyList<Qualification>> GetAllQualificationsByJobSeekerId(int jobSeekerId)
        {
            var experiencesList = await _unitOfWork.GetRepository<Qualification>()
                                            .GetAllWithSpecAsync(new BaseSpecification<Qualification>(x => x.JobSeekerId == jobSeekerId));

            return experiencesList;
        }

    }
}
