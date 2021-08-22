using MediatR;

namespace Grader.Api.Business.Commands.CategoryCreate
{
    public class CategoryCreateCommand : IRequest<CategoryCreateCommandResult>
    {
        public string Name { get; set; }
    }
}
