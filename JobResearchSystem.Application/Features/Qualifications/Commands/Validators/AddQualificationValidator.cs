using FluentValidation;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;

namespace JobResearchSystem.Application.Features.Qualifications.Commands.Validators
{
    public class AddQualificationValidator : AbstractValidator<AddQualificationCommand>
    {
        public AddQualificationValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.SchoolName)
               .NotEmpty().WithMessage("School Name Required")
               .MinimumLength(5).WithMessage("School Name Minimum Length is 1 characters ")
               .MaximumLength(50).WithMessage("School Name Maximum Length is 50 characters ");

            RuleFor(x => x.JobSeekerId)
               .NotEmpty()
               .NotNull();
        }
    }
}
