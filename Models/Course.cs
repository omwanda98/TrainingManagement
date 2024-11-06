using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Models
{
    public class Course
    {
        [Key]
        public string CourseCode { get; set; } // Manually entered code
        [Required]
        public string CourseName { get; set; }
        public int CourseHours { get; set; }
        public decimal CourseCost { get; set; }

        public ICollection<TrainerCourse> TrainerCourses { get; set; } = new List<TrainerCourse>();
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
