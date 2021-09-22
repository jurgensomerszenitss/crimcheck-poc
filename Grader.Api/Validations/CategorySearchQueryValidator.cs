using FluentValidation;
using Grader.Api.Business.Queries;

namespace Grader.Api.Validations
{
    public class CategorySearchQueryValidator : AbstractValidator<CategorySearch.Query>
    {
        public CategorySearchQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0).WithMessage("Page has to be greater than 0");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("PageSize has to be greater than 0");
        }
    }
}
