using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class StudentQuestionIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentQuestions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "First",
                table: "StudentQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fourth",
                table: "StudentQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Second",
                table: "StudentQuestions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Third",
                table: "StudentQuestions",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_QuestionId",
                table: "StudentQuestions",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_StudentQuestions_QuestionId",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "First",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "Fourth",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "Second",
                table: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "Third",
                table: "StudentQuestions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentQuestions",
                table: "StudentQuestions",
                columns: new[] { "QuestionId", "StudentId" });
        }
    }
}
