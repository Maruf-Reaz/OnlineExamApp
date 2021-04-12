using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class Asd22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "Exam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Exam",
                nullable: true);
        }
    }
}
