using FluentValidation;
using Grader.Api.Business.Commands.CourseCreate;

namespace Grader.Api.Validations
{
    public class CourseCreateCommandValidator : AbstractValidator<CourseCreateCommand>
    {
        public CourseCreateCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("Title cannot be longer than 200");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description cannot be longer than 200");

            RuleFor(x => x.ActiveFrom).LessThan(x => x.ActiveTo).WithMessage("Active from has to be earlier than Active to");
            RuleFor(x => x.ActiveTo).GreaterThan(x => x.ActiveFrom).WithMessage("Active from has to be earlier than Active to");

            RuleFor(x => x.ActiveFrom).GreaterThan(x => x.RegistrationFrom).WithMessage("Active from has to be after Registration from");

            RuleFor(x => x.RegistrationFrom).LessThan(x => x.RegistrationTo).WithMessage("Registration from has to be earlier than Registration to");
            RuleFor(x => x.RegistrationTo).GreaterThan(x => x.RegistrationFrom).WithMessage("Registration from has to be earlier than Registration to");

            RuleFor(x => x.RegistrationTo).LessThanOrEqualTo(x => x.ActiveTo).WithMessage("Registration to has to be earlier than Active to");

            RuleFor(x => x.MaxParticipants).GreaterThan(0).WithMessage("Max partipants has to be greater than 0");
            RuleFor(x => x.MinParticipants).GreaterThanOrEqualTo(0).WithMessage("Min partipants has to be greater or equal than 0");
            RuleFor(x => x.MinParticipants).LessThan(x => x.MaxParticipants).WithMessage("Min partipants has to be earlier than Max partipants");

        }
    }
}
