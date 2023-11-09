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

        public override async Task<Qualification?> UpdateAsync(Qualification entity)
        {
            var currentEntity = await _unitOfWork.GetRepository<Qualification>().GetByIdAsync(entity.Id);

            if (currentEntity is null) throw new ValidationException("Qualification Id Not Found");

            entity.JobSeekerId = currentEntity.JobSeekerId;

            return await base.UpdateAsync(entity);
        }
    }
}
