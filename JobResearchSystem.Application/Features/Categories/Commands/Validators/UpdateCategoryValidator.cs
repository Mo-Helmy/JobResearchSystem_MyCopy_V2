using FluentValidation;
using JobResearchSystem.Application.Features.Categories.Commands.Models;

namespace JobResearchSystem.Application.Features.Categories.Commands.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator() { ApplyValidationsRules(); }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("NotEmpty")
                .NotNull().WithMessage("Required");

            RuleFor(x => x.CategoryName)
               .NotEmpty().WithMessage("NotEmpty")
               .NotNull().WithMessage("Category Name Required")
               .MinimumLength(1).WithMessage("Category Name Minimum Length is 1 characters ")
               .MaximumLength(50).WithMessage("Category Name Maximum Length is 50 characters ");
        }
    }
}
