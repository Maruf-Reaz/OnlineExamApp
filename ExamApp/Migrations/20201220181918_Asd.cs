using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class Asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "To",
                table: "Exam",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "From",
                table: "Exam",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Exam",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ExamTypeId",
                table: "Exam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Exam",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ExamTypeId",
                table: "Exam",
                column: "ExamTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_ExamTypes_ExamTypeId",
                table: "Exam",
                column: "ExamTypeId",
                principalTable: "ExamTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exam_ExamTypes_ExamTypeId",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_ExamTypeId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "ExamTypeId",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Exam");

            migrationBuilder.AlterColumn<DateTime>(
                name: "To",
                table: "Exam",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Exam",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }
    }
}
