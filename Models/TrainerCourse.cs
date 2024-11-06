namespace TrainingManagement.Models
{
    public class TrainerCourse
    {
        public string TrainerID { get; set; }
        public Trainer Trainer { get; set; }

        public string CourseCode { get; set; }
        public Course Course { get; set; }
    }
}
