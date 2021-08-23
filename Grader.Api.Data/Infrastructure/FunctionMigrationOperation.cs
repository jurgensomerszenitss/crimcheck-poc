using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics.CodeAnalysis;

namespace Grader.Api.Data.Infrastructure
{

    public class FunctionMigrationOperation : MigrationOperation
    {
        public FunctionMigrationOperation([NotNull] string functionName, string body = null)
        {
            _functionName = functionName;
            _body = body;
        }

        private readonly string _functionName;
        private readonly string _body;

        public string FunctionName => _functionName;
        public string Body => _body;
    }

    public class CreateFunctionOperation : FunctionMigrationOperation
    {
        public CreateFunctionOperation([NotNull] string functionName, [NotNull] string body) : base(functionName, body)
        {
        } 
    }

    public class DropFunctionOperation : FunctionMigrationOperation
    {
        public DropFunctionOperation([NotNull] string functionName) : base(functionName)
        {
        } 
    }
}
