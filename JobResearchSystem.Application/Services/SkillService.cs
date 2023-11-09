using FluentValidation;
using JobResearchSystem.Application.Services.Contract;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Specifications;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobResearchSystem.Application.Services
{
    public class SkillService : GenericService<Skill>, ISkillService
    {
        public SkillService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override async Task<Skill?> CreateAsync(Skill entity)
        {
            var skillSpecification = new BaseSpecification<Skill>(x => x.SkillName.ToLower() == entity.SkillName.ToLower());

            var currentSkill = await _unitOfWork.GetRepository<Skill>().GetByIdWithSpecAsync(skillSpecification);

            if (currentSkill is not null) throw new ValidationException("Skill name must be unique!");

            return await base.CreateAsync(entity);
        }

        public override async Task<Skill?> UpdateAsync(Skill entity)
        {
            var skillSpecification = new BaseSpecification<Skill>(x => x.SkillName.ToLower() == entity.SkillName.ToLower());

            var currentSkill = await _unitOfWork.GetRepository<Skill>().GetByIdWithSpecAsync(skillSpecification);

            if (currentSkill is not null) throw new ValidationException("Skill name must be unique!");

            return await base.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Skill>> AddSkillRangeToJobSeeker(int jobSeekerId, IEnumerable<Skill> skills)
        {
            var jobSeekerSpecification = new BaseSpecification<JobSeeker>(x => x.Id == jobSeekerId)
            {
                Includes = new List<System.Linq.Expressions.Expression<Func<JobSeeker, object>>> { x => x.Skills }
            };

            var currentJobSeeker = await _unitOfWork.GetRepository<JobSeeker>().GetByIdWithSpecAsync(jobSeekerSpecification);

            if (currentJobSeeker is null) throw new ValidationException("JobSeeker Id Not Found");

            foreach (var skill in skills)
            {
                //checked if skill is Already exist in database
                var skillSpecification = new BaseSpecification<Skill>(x => x.SkillName.ToLower() == skill.SkillName.ToLower());

                var currentSkill = await _unitOfWork.GetRepository<Skill>().GetByIdWithSpecAsync(skillSpecification);

                if (currentSkill is not null) 
                {
                    // add skill to jobseeker if it is not already exist
                    if (!currentJobSeeker.Skills.Contains(currentSkill)) currentJobSeeker.Skills.Add(currentSkill); 
                }
                else
                {
                    // create new skill and add it to job seeker
                    var newSkill = await _unitOfWork.GetRepository<Skill>().CreateAsync(skill);
                    if (newSkill is not null)
                        currentJobSeeker.Skills.Add(newSkill);
                }
            }

            await _unitOfWork.Complete();

            return skills;
        }

    }
}
