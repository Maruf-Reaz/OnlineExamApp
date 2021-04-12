using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamApp.Migrations
{
    public partial class BigOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SectionId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    CouurseId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: true),
                    AcademicSessionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRooms_AcademicSessions_AcademicSessionId",
                        column: x => x.AcademicSessionId,
                        principalTable: "AcademicSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRooms_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRooms_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ClassRooms_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ExamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoomStudents",
                columns: table => new
                {
                    ClassRoomId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomStudents", x => new { x.ClassRoomId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ClassRoomStudents_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Topic = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    TotalMark = table.Column<double>(nullable: false),
                    ClassRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exam_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExamId = table.Column<int>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Opton1 = table.Column<string>(nullable: true),
                    Opton2 = table.Column<string>(nullable: true),
                    Opton3 = table.Column<string>(nullable: true),
                    Opton4 = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<int>(nullable: false),
                    TrueFalseAnswer = table.Column<bool>(nullable: false),
                    FillInTheBlanksAnswer = table.Column<string>(nullable: true),
                    Mark = table.Column<double>(nullable: false),
                    PhotoName1 = table.Column<string>(nullable: true),
                    PhotoName2 = table.Column<string>(nullable: true),
                    PhotoName3 = table.Column<string>(nullable: true),
                    PhotoName4 = table.Column<string>(nullable: true),
                    PhotoName5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    DetailedAnswer = table.Column<string>(nullable: true),
                    FillInTheGapAnswer = table.Column<string>(nullable: true),
                    MultipleChoiceANswer = table.Column<int>(nullable: false),
                    TrueFalseAnswer = table.Column<bool>(nullable: false),
                    ObtailedMark = table.Column<double>(nullable: false),
                    PhotoName1 = table.Column<string>(nullable: true),
                    PhotoName2 = table.Column<string>(nullable: true),
                    PhotoName3 = table.Column<string>(nullable: true),
                    PhotoName4 = table.Column<string>(nullable: true),
                    PhotoName5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[,]
                {
                    { 1, "May Include all type of questions", "Class Test" },
                    { 2, "May Include Multiple choice ,true/false/ fillin the blanks questions", "Quiz" },
                    { 3, "May Include all type of questions", "Mid Term" },
                    { 4, "May Include all type of questions", "Final Term" },
                    { 5, "Teachers choice of marking system", "General" }
                });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Detailed Question" },
                    { 2, "Multiple Choice" },
                    { 3, "True/False" },
                    { 4, "Fill in The Gaps" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_AcademicSessionId",
                table: "ClassRooms",
                column: "AcademicSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_CourseId",
                table: "ClassRooms",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_SectionId",
                table: "ClassRooms",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_TeacherId",
                table: "ClassRooms",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomStudents_StudentId",
                table: "ClassRoomStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_ClassRoomId",
                table: "Exam",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeId",
                table: "Questions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_QuestionId",
                table: "StudentAnswers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoomStudents");

            migrationBuilder.DropTable(
                name: "ExamTypes");

            migrationBuilder.DropTable(
                name: "StudentAnswers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "ClassRooms");
        }
    }
}
