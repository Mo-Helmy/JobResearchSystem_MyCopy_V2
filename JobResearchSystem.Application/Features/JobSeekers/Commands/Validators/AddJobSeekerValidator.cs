using FluentValidation;
using JobResearchSystem.Application.Features.JobSeekers.Commands.Models;

namespace JobResearchSystem.Application.Features.JobSeekers.Commands.Validators
{
    public class AddJobSeekerValidator : AbstractValidator<AddJobSeekerCommand>
    {
        public AddJobSeekerValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {
            //RuleFor(x => x.CVFilePath)

        }
    }
}
