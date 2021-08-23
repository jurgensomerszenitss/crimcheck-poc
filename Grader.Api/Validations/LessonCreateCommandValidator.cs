using FluentValidation;
using Grader.Api.Business.Commands.LessonCreate;

namespace Grader.Api.Validations
{
    public class LessonCreateCommandValidator : AbstractValidator<LessonCreateCommand>
    {
        public LessonCreateCommandValidator()
        {
            RuleFor(x => x.Topic).NotNull().NotEmpty().WithMessage("Topic is required");
            RuleFor(x => x.Topic).MaximumLength(200).WithMessage("Topic cannot be longer than 200");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description cannot be longer than 200");
        }
    }
}
