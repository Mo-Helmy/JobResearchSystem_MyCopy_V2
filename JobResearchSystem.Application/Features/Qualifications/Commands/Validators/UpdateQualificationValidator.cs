using FluentValidation;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;

namespace JobResearchSystem.Application.Features.Qualifications.Commands.Validators
{
    public class UpdateQualificationValidator : AbstractValidator<UpdateQualificationCommand>
    {
        public UpdateQualificationValidator() 
        { 
            ApplyValidationsRules(); 
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
               .NotEmpty();

            RuleFor(x => x.SchoolName)
               .NotEmpty().WithMessage("NotEmpty")
               .MinimumLength(5).WithMessage("School Name Minimum Length is 1 characters ")
               .MaximumLength(50).WithMessage("School Name Maximum Length is 50 characters ");
        }
    }
}
