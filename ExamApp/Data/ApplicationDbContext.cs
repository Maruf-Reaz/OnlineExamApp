using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ExamApp.Models.Common.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ExamApp.Models;

namespace ExamApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassRoomStudent>()
                 .HasKey(bc => new { bc.ClassRoomId, bc.StudentId });

            modelBuilder.Entity<ClassRoomStudent>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.ClassRoomStudents)
                .HasForeignKey(bc => bc.StudentId);
            modelBuilder.Entity<ClassRoomStudent>()
                .HasOne(bc => bc.ClassRoom)
                .WithMany(c => c.ClassRoomStudents)
                .HasForeignKey(bc => bc.ClassRoomId);


            





            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole { Id = "a682b56a-6135-4111-a0k0-bdec547e3waz", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "da9a3b0e-8b6f-8529-71d0-4fd255e23f15", CreatedOn = Convert.ToDateTime("2020-01-01"), Description = "Has All Permissions" },
                new ApplicationRole { Id = "d925b59b-7456-1442-d0n0-bdec765e3awv", Name = "Teacher", NormalizedName = "TEACHER", ConcurrencyStamp = "ea9a3b0f-9b5f-7153-81e0-4fd799e23f17", CreatedOn = Convert.ToDateTime("2020-01-01"), Description = "Has Teacher Permissions" },
                new ApplicationRole { Id = "e136b60b-7456-2552-e0o0-bdec765e3awb", Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = "ea9a3b0f-9b5f-7153-81e0-4fd799e23f18", CreatedOn = Convert.ToDateTime("2020-01-01"), Description = "Has Student Permissions" }
             );

            modelBuilder.Entity<UserType>().HasData(
            new UserType { Id = 1, Name = "Admin User" },
            new UserType { Id = 2, Name = "Teacher User" },
            new UserType { Id = 3, Name = "Student User" }
         );
            modelBuilder.Entity<ExamType>().HasData(
              new ExamType { Id = 1, Name = "Class Test", Details = "May Include all type of questions" },
              new ExamType { Id = 2, Name = "Quiz", Details = "May Include Multiple choice ,true/false/ fillin the blanks questions" },
              new ExamType { Id = 3, Name = "Mid Term", Details = "May Include all type of questions" },
              new ExamType { Id = 4, Name = "Final Term", Details = "May Include all type of questions" },
              new ExamType { Id = 5, Name = "General", Details = "Teachers choice of marking system" }
           );
            modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType { Id = 1, Name = "Detailed Question" },
            new QuestionType { Id = 2, Name = "Multiple Choice" },
            new QuestionType { Id = 3, Name = "True/False" },
            new QuestionType { Id = 4, Name = "Fill in The Gaps" }
             );
            modelBuilder.Entity<Grade>().HasData(
            new Grade { Id = 1, FromMark = 80, ToMark = 100, Gpa = 4.00, Alphabet = "A+" },
            new Grade { Id = 2, FromMark = 75, ToMark = 79, Gpa = 3.75, Alphabet = "A" },
            new Grade { Id = 3, FromMark = 70, ToMark = 74, Gpa = 3.50, Alphabet = "A-" },
            new Grade { Id = 4, FromMark = 65, ToMark = 69, Gpa = 3.25, Alphabet = "B+" },
            new Grade { Id = 5, FromMark = 60, ToMark = 64, Gpa = 3.00, Alphabet = "B" },
            new Grade { Id = 6, FromMark = 55, ToMark = 59, Gpa = 2.75, Alphabet = "B-" },
            new Grade { Id = 7, FromMark = 50, ToMark = 54, Gpa = 2.50, Alphabet = "C+" },
            new Grade { Id = 8, FromMark = 45, ToMark = 49, Gpa = 2.25, Alphabet = "C" },
            new Grade { Id = 9, FromMark = 40, ToMark = 44, Gpa = 2.20, Alphabet = "D" },
            new Grade { Id = 10, FromMark = 0, ToMark = 39, Gpa = 0.00, Alphabet = "F" }
         );



            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { Id = "8ab6ee61-f36c-41b1-ae27-dbb23cbfb507", UserName = "Admin", NormalizedUserName = "ADMIN", Email = "test@mail.com", NormalizedEmail = "TEST@MAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==", SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EHJ", ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2d", UserTypeId = 1 },
                new ApplicationUser() { Id = "8ab6ee62-f37c-42b2-ae27-dbb11cbfb508", UserName = "Teacher", NormalizedUserName = "USER1", Email = "test@mail.com", NormalizedEmail = "TEST@MAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==", SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EHK", ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2e", UserTypeId = 2 },
                new ApplicationUser() { Id = "8ab6ee63-f38c-43b3-ae27-dbb22cbfb509", UserName = "Student", NormalizedUserName = "USER2", Email = "test@mail.com", NormalizedEmail = "TEST@MAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==", SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EPL", ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2f", UserTypeId = 3 }

             );


        }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<AcademicSession> AcademicSessions { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<ClassRoomStudent> ClassRoomStudents { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<StudentAnswer> StudentAnswers { get; set; }
        public DbSet<StudentQuestion> StudentQuestions { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SeriesExam> SeriesExams { get; set; }
        public DbSet<SeriesExamItem> SeriesExamItems { get; set; }

    }
}
