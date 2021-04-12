using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class GradeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FromMark = table.Column<double>(nullable: false),
                    ToMark = table.Column<double>(nullable: false),
                    Alphabet = table.Column<string>(nullable: true),
                    Gpa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Alphabet", "FromMark", "Gpa", "ToMark" },
                values: new object[,]
                {
                    { 1, "A+", 80.0, 4.0, 100.0 },
                    { 2, "A", 75.0, 3.75, 79.0 },
                    { 3, "A-", 70.0, 3.5, 74.0 },
                    { 4, "B+", 65.0, 3.25, 69.0 },
                    { 5, "B", 60.0, 3.0, 64.0 },
                    { 6, "B-", 55.0, 2.75, 59.0 },
                    { 7, "C+", 50.0, 2.5, 54.0 },
                    { 8, "C", 45.0, 2.25, 49.0 },
                    { 9, "D", 40.0, 2.2000000000000002, 44.0 },
                    { 10, "F", 0.0, 0.0, 39.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}
