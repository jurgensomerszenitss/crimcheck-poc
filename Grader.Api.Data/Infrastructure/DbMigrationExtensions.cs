using Microsoft.EntityFrameworkCore.Migrations;

namespace Grader.Api.Data.Infrastructure
{
    public static class DbMigrationExtensions
    {
        public static void CreateTrigger(this MigrationBuilder migrationBuilder, string tableName, string function)
        {
            migrationBuilder.Operations.Add(new CreateTriggerOperation(tableName, function));
        }

        public static void DropTrigger(this MigrationBuilder migrationBuilder, string tableName, string function)
        {
            migrationBuilder.Operations.Add(new DropTriggerOperation(tableName, function));
        }

        public static void CreateFunction(this MigrationBuilder migrationBuilder, string functionName, string body)
        {
            migrationBuilder.Operations.Add(new CreateFunctionOperation(functionName, body));
        }

        public static void DropFunction(this MigrationBuilder migrationBuilder, string functionName)
        {
            migrationBuilder.Operations.Add(new DropFunctionOperation(functionName));
        }
    }
}
