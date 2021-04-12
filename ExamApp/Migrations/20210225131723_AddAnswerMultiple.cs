using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class AddAnswerMultiple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOption1Correct",
                table: "StudentAnswers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption2Correct",
                table: "StudentAnswers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption3Correct",
                table: "StudentAnswers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption4Correct",
                table: "StudentAnswers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOption1Correct",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "IsOption2Correct",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "IsOption3Correct",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "IsOption4Correct",
                table: "StudentAnswers");
        }
    }
}
