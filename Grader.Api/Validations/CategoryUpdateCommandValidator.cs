using FluentValidation;
using Grader.Api.Business.Commands.CategoryUpdate;

namespace Grader.Api.Validations
{
    public class CategoryUpdateCommandValidator : AbstractValidator<CategoryUpdateCommand>
    {
        public CategoryUpdateCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MaximumLength(200).WithMessage("Name cannot be longer than 200");
        }
    }
}
