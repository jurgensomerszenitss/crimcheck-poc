using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace Grader.Api.Data.Infrastructure
{
    public class PostgresMigrationsGenerator : NpgsqlMigrationsSqlGenerator
    {
        public PostgresMigrationsGenerator([NotNullAttribute] MigrationsSqlGeneratorDependencies dependencies, [NotNullAttribute] INpgsqlOptions npgsqlOptions) : base(dependencies, npgsqlOptions)
        {
        }

        protected override void Generate(MigrationOperation operation,IModel model,MigrationCommandListBuilder builder)
        {
            if (operation is CreateTriggerOperation createTriggerOperation)
            {
                Generate(createTriggerOperation, builder);
            }
            else if ( operation is DropTriggerOperation dropTriggerOperation)
            {
                Generate(dropTriggerOperation, builder);
            }
            else if (operation is CreateFunctionOperation createFunctionOperation)
            {
                Generate(createFunctionOperation, builder);
            }
            else if (operation is DropFunctionOperation dropFunctionOperation)
            {
                Generate(dropFunctionOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }
        }

        private void Generate(CreateTriggerOperation operation, MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper;

            builder
                .Append("CREATE TRIGGER ")
                .Append(sqlHelper.DelimitIdentifier(operation.TriggerName))
                .Append(" BEFORE INSERT OR UPDATE ON ")
                .Append(sqlHelper.DelimitIdentifier(operation.TableName))
                .Append(" FOR EACH ROW EXECUTE PROCEDURE ")
                .Append(sqlHelper.DelimitIdentifier(operation.Function))
                .Append("()")
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }

        private void Generate(DropTriggerOperation operation, MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper; 

            builder
                .Append("DROP TRIGGER IF EXISTS")
                .Append(sqlHelper.DelimitIdentifier(operation.TriggerName))
                .Append(" ON ")
                .Append(sqlHelper.DelimitIdentifier(operation.TableName))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }

        private void Generate(CreateFunctionOperation operation, MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper; 

            builder
                .Append("CREATE FUNCTION ")
                .Append(sqlHelper.DelimitIdentifier(operation.FunctionName))
                .Append("() RETURNS TRIGGER AS $$ BEGIN ")
                .AppendLine(operation.Body)
                .Append(" END $$ LANGUAGE plpgsql")
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }

        private void Generate(DropFunctionOperation operation, MigrationCommandListBuilder builder)
        {
            var sqlHelper = Dependencies.SqlGenerationHelper; 

            builder
                .Append("DROP FUNCTION ")
                .Append(sqlHelper.DelimitIdentifier(operation.FunctionName))
                .AppendLine(sqlHelper.StatementTerminator)
                .EndCommand();
        }
    }
}
