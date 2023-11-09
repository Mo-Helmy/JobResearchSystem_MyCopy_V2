using FluentValidation;
using JobResearchSystem.Application.Features.Qualifications.Commands.Models;

namespace JobResearchSystem.Application.Features.Qualifications.Commands.Validators
{
    public class DeleteQualificationValidator : AbstractValidator<DeleteQualificationCommand>
    {
        public DeleteQualificationValidator() 
        { 
            ApplyValidationsRules(); 
        }
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.QualificationId).NotEmpty();
        }
    }
}
