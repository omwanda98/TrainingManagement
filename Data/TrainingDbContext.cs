using Microsoft.EntityFrameworkCore;
using TrainingManagement.Models;

namespace TrainingManagement.Data
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options) { }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<TrainerCourse> TrainerCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define precision for CourseCost
            modelBuilder.Entity<Course>()
                .Property(c => c.CourseCost)
                .HasColumnType("decimal(18,2)");

            // Define composite key for StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentID, sc.CourseCode });

            // Configure relationships for StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentID);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseCode);

            // Define composite key for TrainerCourse
            modelBuilder.Entity<TrainerCourse>()
                .HasKey(tc => new { tc.TrainerID, tc.CourseCode });

            // Configure relationships for TrainerCourse
            modelBuilder.Entity<TrainerCourse>()
                .HasOne(tc => tc.Trainer)
                .WithMany(t => t.TrainerCourses)
                .HasForeignKey(tc => tc.TrainerID);

            modelBuilder.Entity<TrainerCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TrainerCourses)
                .HasForeignKey(tc => tc.CourseCode);
        }
    }
}
