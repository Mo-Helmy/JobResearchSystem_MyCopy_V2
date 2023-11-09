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
    public class ExperienceService : GenericService<Experience>, IExperienceService
    {
        public ExperienceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IReadOnlyList<Experience>> GetAllExperiencesByJobSeekerId(int jobSeekerId)
        {
            var experiencesList = await _unitOfWork.GetRepository<Experience>()
                                            .GetAllWithSpecAsync(new BaseSpecification<Experience>(x => x.JobSeekerId == jobSeekerId));

            return experiencesList;
        }

        public override async Task<Experience?> UpdateAsync(Experience entity)
        {
            var currentEntity = await _unitOfWork.GetRepository<Experience>().GetByIdAsync(entity.Id);

            if (currentEntity is null) throw new ValidationException("Experience Id Not Found");

            entity.JobSeekerId = currentEntity.JobSeekerId;

            return await base.UpdateAsync(entity);
        }
    }
}
