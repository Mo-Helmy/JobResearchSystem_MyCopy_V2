using FluentValidation;
using JobResearchSystem.Application.Features.Skills.Commands.Models;

namespace JobResearchSystem.Application.Features.Skills.Commands.Validators
{
    public class AddSkillValidator : AbstractValidator<AddSkillCommand>
    {
        public AddSkillValidator() 
        { 
            ApplyValidationsRules(); 
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SkillName)
               .NotEmpty().WithMessage("NotEmpty")
               .NotNull().WithMessage("Skill Name Required")
               .MinimumLength(1).WithMessage("Skill Name Minimum Length is 1 characters ")
               .MaximumLength(50).WithMessage("Skill Name Maximum Length is 50 characters ");
        }
    }
}
