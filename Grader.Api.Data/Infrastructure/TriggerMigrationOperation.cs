using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics.CodeAnalysis;

namespace Grader.Api.Data.Infrastructure
{
    public class TriggerMigrationOperation : MigrationOperation
    {
        public TriggerMigrationOperation([NotNull] string tableName, [NotNull] string function)
        {
            _tableName = tableName;
            _function = function;
        }

        private readonly string _tableName;
        private readonly string _function;

        public string TableName => _tableName;
        public string Function => _function;
        internal string TriggerName => $"{_tableName}_upsert_trigger";
    }

    public class CreateTriggerOperation : TriggerMigrationOperation
    {
        public CreateTriggerOperation([NotNull] string tableName, [NotNull] string function) : base(tableName, function)
        {
        } 
    }

    public class DropTriggerOperation : TriggerMigrationOperation
    {
        public DropTriggerOperation([NotNull] string tableName, [NotNull] string function) : base(tableName, function)
        {
        } 
    } 
     
}
