namespace School.Data.Entities
{


    public class InstructorQualification : BaseEntity
    {
        [Required]
        public int InstructorId { get; set; }

        [Required]
        [MaxLength(EntityConstants.MaxTitleLength)]
        public string QualificationTitle { get; set; }

        [Required]
        public QualificationType QualificationType { get; set; }

        // Navigation Property back to Instructor
        public virtual Instructor Instructor { get; set; }
    }
}
