namespace School.Data.Entities
{
    public class InstructorSubject
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
        public DateTime AssignmentDate { get; set; }

        // Navigation Properties
        public virtual Instructor Instructor { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
