using FluentValidation;
using Grader.Api.Business.Commands;

namespace Grader.Api.Validations
{
    public class CategoryCreateCommandValidator : AbstractValidator<CategoryCreate.Command>
    {
        public CategoryCreateCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Name cannot be longer than 200");
        }
    }
}
