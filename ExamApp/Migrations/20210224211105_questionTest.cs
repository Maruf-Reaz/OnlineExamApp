using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class questionTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalQuestions",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalQuestions",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
