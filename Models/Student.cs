using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Models
{
    public class Student
    {
        [Key]
        public string StudentID { get; set; } // Format SAD0001, SAD0002, etc.
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
