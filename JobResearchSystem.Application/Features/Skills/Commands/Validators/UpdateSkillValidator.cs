using FluentValidation;
using JobResearchSystem.Application.Features.Skills.Commands.Models;

namespace JobResearchSystem.Application.Features.Skills.Commands.Validators
{
    public class UpdateSkillValidator : AbstractValidator<UpdateSkillCommand>
    {
        public UpdateSkillValidator() 
        { 
            ApplyValidationsRules(); 
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("NotEmpty")
                .NotNull().WithMessage("Required");

            RuleFor(x => x.SkillName)
               .NotEmpty().WithMessage("NotEmpty")
               .NotNull().WithMessage("Skill Name Required")
               .MinimumLength(1).WithMessage("Skill Name Minimum Length is 1 characters ")
               .MaximumLength(50).WithMessage("Skill Name Maximum Length is 50 characters ");
        }
    }
}
