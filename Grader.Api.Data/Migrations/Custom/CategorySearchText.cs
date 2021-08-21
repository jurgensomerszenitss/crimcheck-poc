using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Grader.Api.Data.Migrations.Custom
{
    internal static class CategorySearchText
    {
        internal static MigrationBuilder Up(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpFunction();
            migrationBuilder.UpTrigger();            
            migrationBuilder.UpData();

            return migrationBuilder;
        }

        internal static MigrationBuilder Down(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DownTrigger();
            migrationBuilder.DownFunction();            

            return migrationBuilder;
        }

        private static OperationBuilder<SqlOperation> UpTrigger(this MigrationBuilder migrationBuilder)
        {

            var sql = @"CREATE TRIGGER category_update_trigger BEFORE INSERT OR UPDATE ON category FOR EACH ROW EXECUTE PROCEDURE category_update();";
            return migrationBuilder.Sql(sql);
        }

        private static OperationBuilder<SqlOperation> UpFunction(this MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE FUNCTION category_update() RETURNS TRIGGER AS $$ 
BEGIN 	
	new.search_text:= setweight(to_tsvector(COALESCE('new.name', '')), 'A') ;
	return new;
END
$$ LANGUAGE plpgsql;";
            return migrationBuilder.Sql(sql);
        }

        private static OperationBuilder<SqlOperation> DownFunction(this MigrationBuilder migrationBuilder)
        {
            return migrationBuilder.Sql("DROP FUNCTION category_update CASCADE;");
        }

        private static OperationBuilder<SqlOperation> DownTrigger(this MigrationBuilder migrationBuilder)
        {
            return migrationBuilder.Sql("DROP TRIGGER IF EXISTS category_update_trigger ON \"category\"; ");
        }

        private static void UpData(this MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE \"category\" SET search_text = setweight(to_tsvector(coalesce(name, '')), 'A');");
        }
    }
}
