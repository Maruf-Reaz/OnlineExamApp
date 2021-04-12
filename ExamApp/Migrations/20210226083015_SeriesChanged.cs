using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class SeriesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesExams_AcademicSessions_AcademicSessionId",
                table: "SeriesExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesExams_Exams_ExamId",
                table: "SeriesExams");

            migrationBuilder.DropIndex(
                name: "IX_SeriesExams_ExamId",
                table: "SeriesExams");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "SeriesExams");

            migrationBuilder.RenameColumn(
                name: "AcademicSessionId",
                table: "SeriesExams",
                newName: "ClassRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesExams_AcademicSessionId",
                table: "SeriesExams",
                newName: "IX_SeriesExams_ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesExams_SelectedExamId",
                table: "SeriesExams",
                column: "SelectedExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesExams_ClassRooms_ClassRoomId",
                table: "SeriesExams",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesExams_Exams_SelectedExamId",
                table: "SeriesExams",
                column: "SelectedExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesExams_ClassRooms_ClassRoomId",
                table: "SeriesExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesExams_Exams_SelectedExamId",
                table: "SeriesExams");

            migrationBuilder.DropIndex(
                name: "IX_SeriesExams_SelectedExamId",
                table: "SeriesExams");

            migrationBuilder.RenameColumn(
                name: "ClassRoomId",
                table: "SeriesExams",
                newName: "AcademicSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesExams_ClassRoomId",
                table: "SeriesExams",
                newName: "IX_SeriesExams_AcademicSessionId");

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "SeriesExams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeriesExams_ExamId",
                table: "SeriesExams",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesExams_AcademicSessions_AcademicSessionId",
                table: "SeriesExams",
                column: "AcademicSessionId",
                principalTable: "AcademicSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesExams_Exams_ExamId",
                table: "SeriesExams",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
