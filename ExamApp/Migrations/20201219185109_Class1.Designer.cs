﻿// <auto-generated />
using System;
using ExamApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExamApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201219185109_Class1")]
    partial class Class1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExamApp.Models.AcademicSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstitutionId");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("AcademicSessions");
                });

            modelBuilder.Entity("ExamApp.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicSessionId");

                    b.Property<int>("CourseId");

                    b.Property<int>("SectionId");

                    b.Property<int>("Status");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("AcademicSessionId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SectionId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassRooms");
                });

            modelBuilder.Entity("ExamApp.Models.ClassRoomStudent", b =>
                {
                    b.Property<int>("ClassRoomId");

                    b.Property<int>("StudentId");

                    b.HasKey("ClassRoomId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("ClassRoomStudents");
                });

            modelBuilder.Entity("ExamApp.Models.Common.Authentication.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "a682b56a-6135-4111-a0k0-bdec547e3waz",
                            ConcurrencyStamp = "da9a3b0e-8b6f-8529-71d0-4fd255e23f15",
                            CreatedOn = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Has All Permissions",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "d925b59b-7456-1442-d0n0-bdec765e3awv",
                            ConcurrencyStamp = "ea9a3b0f-9b5f-7153-81e0-4fd799e23f17",
                            CreatedOn = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Has Teacher Permissions",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "e136b60b-7456-2552-e0o0-bdec765e3awb",
                            ConcurrencyStamp = "ea9a3b0f-9b5f-7153-81e0-4fd799e23f18",
                            CreatedOn = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Has Student Permissions",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("ExamApp.Models.Common.Authentication.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("InstitutionId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserTypeId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "8ab6ee61-f36c-41b1-ae27-dbb23cbfb507",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2d",
                            Email = "test@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST@MAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EHJ",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            UserTypeId = 1
                        },
                        new
                        {
                            Id = "8ab6ee62-f37c-42b2-ae27-dbb11cbfb508",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2e",
                            Email = "test@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST@MAIL.COM",
                            NormalizedUserName = "USER1",
                            PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EHK",
                            TwoFactorEnabled = false,
                            UserName = "Teacher",
                            UserTypeId = 2
                        },
                        new
                        {
                            Id = "8ab6ee63-f38c-43b3-ae27-dbb22cbfb509",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2f",
                            Email = "test@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST@MAIL.COM",
                            NormalizedUserName = "USER2",
                            PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EPL",
                            TwoFactorEnabled = false,
                            UserName = "Student",
                            UserTypeId = 3
                        });
                });

            modelBuilder.Entity("ExamApp.Models.Common.Authentication.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Teacher User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Student User"
                        });
                });

            modelBuilder.Entity("ExamApp.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Name");

                    b.Property<int>("SemesterId");

                    b.Property<string>("ShortName");

                    b.Property<int?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SemesterId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ExamApp.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstitutionId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ExamApp.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InstitutionId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("ExamApp.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassRoomId");

                    b.Property<string>("Details");

                    b.Property<DateTime>("From");

                    b.Property<string>("Name");

                    b.Property<DateTime>("To");

                    b.Property<string>("Topic");

                    b.Property<double>("TotalMark");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("ExamApp.Models.ExamType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExamTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Details = "May Include all type of questions",
                            Name = "Class Test"
                        },
                        new
                        {
                            Id = 2,
                            Details = "May Include Multiple choice ,true/false/ fillin the blanks questions",
                            Name = "Quiz"
                        },
                        new
                        {
                            Id = 3,
                            Details = "May Include all type of questions",
                            Name = "Mid Term"
                        },
                        new
                        {
                            Id = 4,
                            Details = "May Include all type of questions",
                            Name = "Final Term"
                        },
                        new
                        {
                            Id = 5,
                            Details = "Teachers choice of marking system",
                            Name = "General"
                        });
                });

            modelBuilder.Entity("ExamApp.Models.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("ExamApp.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorrectAnswer");

                    b.Property<string>("Description");

                    b.Property<int>("ExamId");

                    b.Property<string>("FillInTheBlanksAnswer");

                    b.Property<double>("Mark");

                    b.Property<string>("Opton1");

                    b.Property<string>("Opton2");

                    b.Property<string>("Opton3");

                    b.Property<string>("Opton4");

                    b.Property<string>("PhotoName1");

                    b.Property<string>("PhotoName2");

                    b.Property<string>("PhotoName3");

                    b.Property<string>("PhotoName4");

                    b.Property<string>("PhotoName5");

                    b.Property<int>("QuestionTypeId");

                    b.Property<bool>("TrueFalseAnswer");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ExamApp.Models.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Detailed Question"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Multiple Choice"
                        },
                        new
                        {
                            Id = 3,
                            Name = "True/False"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fill in The Gaps"
                        });
                });

            modelBuilder.Entity("ExamApp.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FullName");

                    b.Property<string>("Name");

                    b.Property<int>("NumericValue");

                    b.Property<int?>("SemesterId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SemesterId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ExamApp.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name");

                    b.Property<int>("NumericValue");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("ExamApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Email");

                    b.Property<string>("IdNo");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("SectionId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ExamApp.Models.StudentAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DetailedAnswer");

                    b.Property<string>("FillInTheGapAnswer");

                    b.Property<int>("MultipleChoiceANswer");

                    b.Property<double>("ObtailedMark");

                    b.Property<string>("PhotoName1");

                    b.Property<string>("PhotoName2");

                    b.Property<string>("PhotoName3");

                    b.Property<string>("PhotoName4");

                    b.Property<string>("PhotoName5");

                    b.Property<int>("QuestionId");

                    b.Property<bool>("TrueFalseAnswer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("StudentAnswers");
                });

            modelBuilder.Entity("ExamApp.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("DesignationId");

                    b.Property<string>("Email");

                    b.Property<string>("IdNo");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNo");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DesignationId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ExamApp.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ExamApp.Models.AcademicSession", b =>
                {
                    b.HasOne("ExamApp.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.ClassRoom", b =>
                {
                    b.HasOne("ExamApp.Models.AcademicSession", "AcademicSession")
                        .WithMany()
                        .HasForeignKey("AcademicSessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.ClassRoomStudent", b =>
                {
                    b.HasOne("ExamApp.Models.ClassRoom", "ClassRoom")
                        .WithMany("ClassRoomStudents")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Student", "Student")
                        .WithMany("ClassRoomStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Common.Authentication.ApplicationUser", b =>
                {
                    b.HasOne("ExamApp.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId");

                    b.HasOne("ExamApp.Models.Common.Authentication.UserType", "UserType")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Course", b =>
                {
                    b.HasOne("ExamApp.Models.Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("ExamApp.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("ExamApp.Models.Department", b =>
                {
                    b.HasOne("ExamApp.Models.Institution", "Institution")
                        .WithMany("Departments")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Designation", b =>
                {
                    b.HasOne("ExamApp.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Exam", b =>
                {
                    b.HasOne("ExamApp.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Question", b =>
                {
                    b.HasOne("ExamApp.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Section", b =>
                {
                    b.HasOne("ExamApp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Semester")
                        .WithMany("Sections")
                        .HasForeignKey("SemesterId");
                });

            modelBuilder.Entity("ExamApp.Models.Semester", b =>
                {
                    b.HasOne("ExamApp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Student", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ExamApp.Models.Section", "Section")
                        .WithMany("Students")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.StudentAnswer", b =>
                {
                    b.HasOne("ExamApp.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.Teacher", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("ExamApp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Designation", "Designation")
                        .WithMany("Teachers")
                        .HasForeignKey("DesignationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExamApp.Models.UserProfile", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ExamApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
