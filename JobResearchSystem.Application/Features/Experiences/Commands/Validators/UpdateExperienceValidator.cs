using FluentValidation;
using JobResearchSystem.Application.Features.Experiences.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;

namespace JobResearchSystem.Application.Features.Experiences.Commands.Validators
{
    public class UpdateExperienceValidator : AbstractValidator<UpdateExperienceCommand>
    {
        public UpdateExperienceValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .NotNull();

            //RuleFor(x => x.ExperienceTitle)
            //   .NotEmpty().WithMessage("NotEmpty")
            //   .MinimumLength(5).WithMessage("Skill Name Minimum Length is 1 characters ")
            //   .MaximumLength(50).WithMessage("Skill Name Maximum Length is 50 characters ");

            //RuleFor(x => x.ExperienceCompanyName)
            //   .NotEmpty()
            //   .MinimumLength(5)
            //   .MaximumLength(50);
        }
    }
}
