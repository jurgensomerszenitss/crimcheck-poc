using FluentValidation;
using Grader.Api.Business.Commands.LessonUpdate;

namespace Grader.Api.Validations
{
    public class LessonUpdateCommandValidator : AbstractValidator<LessonUpdateCommand>
    {
        public LessonUpdateCommandValidator()
        {
            RuleFor(x => x.Topic).NotNull().NotEmpty().WithMessage("Topic is required");
            RuleFor(x => x.Topic).MaximumLength(200).WithMessage("Topic cannot be longer than 200");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description cannot be longer than 200");
        }
    }
}
