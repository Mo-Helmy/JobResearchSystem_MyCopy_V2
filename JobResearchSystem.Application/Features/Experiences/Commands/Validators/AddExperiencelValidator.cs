using FluentValidation;
using JobResearchSystem.Application.Features.Experiences.Commands.Models;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;

namespace JobResearchSystem.Application.Features.Experiences.Commands.Validators
{
    public class AddExperienceValidator : AbstractValidator<AddExperienceCommand>
    {
        public AddExperienceValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.ExperienceTitle)
               .NotEmpty().WithMessage("NotEmpty")
               .NotNull().WithMessage("Experience Name Required")
               .MinimumLength(5).WithMessage("Skill Name Minimum Length is 1 characters ")
               .MaximumLength(50).WithMessage("Skill Name Maximum Length is 50 characters ");
            
            RuleFor(x => x.ExperienceCompanyName)
               .NotEmpty()
               .NotNull()
               .MinimumLength(5)
               .MaximumLength(50);
            
            RuleFor(x => x.JobSeekerId)
               .NotEmpty()
               .NotNull();
        }
    }
}
