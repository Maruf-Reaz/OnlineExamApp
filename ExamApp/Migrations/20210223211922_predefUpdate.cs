using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class predefUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ActualObtailedMark",
                table: "StudentAnswers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ActualMark",
                table: "Questions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption1Correct",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption2Correct",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption3Correct",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOption4Correct",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "EachQuestionMark",
                table: "Exams",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasSets",
                table: "Exams",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuestions",
                table: "Exams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentQuestions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestions", x => new { x.QuestionId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StudentQuestions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestions_StudentId",
                table: "StudentQuestions",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentQuestions");

            migrationBuilder.DropColumn(
                name: "ActualObtailedMark",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "ActualMark",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsOption1Correct",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsOption2Correct",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsOption3Correct",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsOption4Correct",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "EachQuestionMark",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "HasSets",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "TotalQuestions",
                table: "Exams");
        }
    }
}
