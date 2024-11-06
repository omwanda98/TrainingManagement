using System.ComponentModel.DataAnnotations;

namespace TrainingManagement.Models
{
    public class Trainer
    {
        [Key]
        public string TrainerID { get; set; } // Format TAD0001, TAD0002, etc.
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string IdNumber { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<TrainerCourse> TrainerCourses { get; set; } = new List<TrainerCourse>();
    }
}
