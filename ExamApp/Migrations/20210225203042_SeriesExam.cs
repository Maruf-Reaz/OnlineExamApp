using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class SeriesExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeriesExams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SelectedExamId = table.Column<int>(nullable: true),
                    ExamId = table.Column<int>(nullable: true),
                    AcademicSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesExams_AcademicSessions_AcademicSessionId",
                        column: x => x.AcademicSessionId,
                        principalTable: "AcademicSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SeriesExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SeriesExamItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExamId = table.Column<int>(nullable: false),
                    SeriesExamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesExamItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesExamItems_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SeriesExamItems_SeriesExams_SeriesExamId",
                        column: x => x.SeriesExamId,
                        principalTable: "SeriesExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeriesExamItems_ExamId",
                table: "SeriesExamItems",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesExamItems_SeriesExamId",
                table: "SeriesExamItems",
                column: "SeriesExamId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesExams_AcademicSessionId",
                table: "SeriesExams",
                column: "AcademicSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesExams_ExamId",
                table: "SeriesExams",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesExamItems");

            migrationBuilder.DropTable(
                name: "SeriesExams");
        }
    }
}
