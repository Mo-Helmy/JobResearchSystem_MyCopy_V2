using FluentValidation;
using JobResearchSystem.Application.Features.Skills.Commands.Models;
using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Specifications;
using JobResearchSystem.Infrastructure.UnitOfWorks.Contract;

namespace JobResearchSystem.Application.Features.Skills.Commands.Validators
{
    public class AddSkillRangeValidator : AbstractValidator<AddSkillRangeCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddSkillRangeValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.JobSeekerId)
                .NotEmpty()
                .NotNull();

            //// For Testing purpose
            //RuleForEach(x => x.Skills).MustAsync(async (x, _) =>
            //{
            //    return await unitOfWork.GetRepository<Skill>().GetByIdWithSpecAsync(new BaseSpecification<Skill>(entity => entity.SkillName == x.SkillName)) is null;
            //}).WithMessage("my skill error message");
        }

    }
}
