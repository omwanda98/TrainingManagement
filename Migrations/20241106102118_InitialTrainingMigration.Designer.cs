﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingManagement.Data;

#nullable disable

namespace TrainingManagement.Migrations
{
    [DbContext(typeof(TrainingDbContext))]
    [Migration("20241106102118_InitialTrainingMigration")]
    partial class InitialTrainingMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainingManagement.Models.Course", b =>
                {
                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CourseCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CourseHours")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseCode");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TrainingManagement.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TrainingManagement.Models.StudentCourse", b =>
                {
                    b.Property<string>("StudentID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentID", "CourseCode");

                    b.HasIndex("CourseCode");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("TrainingManagement.Models.Trainer", b =>
                {
                    b.Property<string>("TrainerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainerID");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("TrainingManagement.Models.TrainerCourse", b =>
                {
                    b.Property<string>("TrainerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TrainerID", "CourseCode");

                    b.HasIndex("CourseCode");

                    b.ToTable("TrainerCourses");
                });

            modelBuilder.Entity("TrainingManagement.Models.StudentCourse", b =>
                {
                    b.HasOne("TrainingManagement.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingManagement.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("TrainingManagement.Models.TrainerCourse", b =>
                {
                    b.HasOne("TrainingManagement.Models.Course", "Course")
                        .WithMany("TrainerCourses")
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingManagement.Models.Trainer", "Trainer")
                        .WithMany("TrainerCourses")
                        .HasForeignKey("TrainerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("TrainingManagement.Models.Course", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("TrainerCourses");
                });

            modelBuilder.Entity("TrainingManagement.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("TrainingManagement.Models.Trainer", b =>
                {
                    b.Navigation("TrainerCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
