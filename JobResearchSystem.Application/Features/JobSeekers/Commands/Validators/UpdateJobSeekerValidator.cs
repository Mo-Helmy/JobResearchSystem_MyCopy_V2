using FluentValidation;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;

namespace JobResearchSystem.Application.Features.Skills.Commands.Validators
{
    public class UpdateJobSeekerValidator : AbstractValidator<UpdateJobSeekerCommand>
    {
        public UpdateJobSeekerValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("NotEmpty")
                .NotNull().WithMessage("Required");
        }
    }
}
