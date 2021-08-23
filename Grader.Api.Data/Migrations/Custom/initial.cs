using Grader.Api.Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grader.Api.Data.Migrations
{
    partial class initial
    {
        private static void CustomUp(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateFunction(
                functionName: "category_update",
                body: @"new.search_text:= setweight(to_tsvector(COALESCE('new.name', '')), 'A') ;
                        return new; ");

            migrationBuilder.CreateFunction(
                functionName: "course_update",
                body: @"new.search_text:= setweight(to_tsvector(COALESCE('new.title', '')), 'A') || setweight(to_tsvector(COALESCE(new.description, '')), 'B');
                        return new; ");

            migrationBuilder.CreateFunction(
              functionName: "lesson_update",
              body: @"new.search_text:= setweight(to_tsvector(COALESCE('new.topic', '')), 'A') || setweight(to_tsvector(COALESCE(new.description, '')), 'B');
                        return new; ");

            migrationBuilder.CreateTrigger(
                tableName: "category",
                function: "category_update");


            migrationBuilder.CreateTrigger(
                tableName: "course",
                function: "course_update");

            migrationBuilder.CreateTrigger(
              tableName: "lesson",
              function: "lesson_update");
        }

        private static void CustomDown(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTrigger(
                tableName: "course",
                function: "course_update");

            migrationBuilder.DropTrigger(
                tableName: "category",
                function: "category_update");

            migrationBuilder.DropTrigger(
               tableName: "lesson",
               function: "lesson_update");

            migrationBuilder.DropFunction(
                functionName: "course_update");

            migrationBuilder.DropFunction(
                functionName: "category_update");

            migrationBuilder.DropFunction(
                functionName: "lesson_update");
        }
    }
}
