using FluentValidation;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;

namespace JobResearchSystem.Application.Features.JobSeekers.Commands.Validators
{
    public class DeleteJobSeekerValidator : AbstractValidator<DeleteJobSeekerCommand>
    {
        public DeleteJobSeekerValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.JobSeekerId)
                .NotEmpty().WithMessage("NotEmpty")
                .NotNull().WithMessage("Required");
        }
    }
}
