using FluentValidation;
using JobResearchSystem.Application.Features.Experiences.Commands.Models;

namespace JobResearchSystem.Application.Features.Experiences.Commands.Validators
{
    public class DeleteExperienceValidator : AbstractValidator<DeleteExperienceCommand>
    {
        public DeleteExperienceValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.ExperienceId)
                .NotEmpty().WithMessage("NotEmpty")
                .NotNull().WithMessage("Required");
        }
    }
}
