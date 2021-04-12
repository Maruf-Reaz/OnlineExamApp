using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class Class1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Courses_CourseId",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "CouurseId",
                table: "ClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "ClassRooms",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Courses_CourseId",
                table: "ClassRooms",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Courses_CourseId",
                table: "ClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "ClassRooms",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CouurseId",
                table: "ClassRooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Courses_CourseId",
                table: "ClassRooms",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
