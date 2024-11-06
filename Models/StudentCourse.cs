using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Models
{
    public class StudentCourse
    {
        public string StudentID { get; set; }
        public Student Student { get; set; }

        public string CourseCode { get; set; }
        public Course Course { get; set; }
    }
}
