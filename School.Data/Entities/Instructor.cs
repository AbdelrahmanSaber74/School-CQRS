namespace School.Data.Entities
{
    public class Instructor : BaseEntity
    {

        [Required]
        [MaxLength(EntityConstants.MaxNameLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(EntityConstants.MaxNameLength)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [EmailAddress]
        [MaxLength(EntityConstants.MaxEmailLength)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(EntityConstants.MaxPhoneLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? TerminationDate { get; set; }

        [Required]
        public InstructorStatus Status { get; set; }

        [Required]
        public AcademicRank AcademicRank { get; set; }

        [MaxLength(EntityConstants.MaxQualificationLength)]
        public string Qualification { get; set; }

        [MaxLength(EntityConstants.MaxSpecializationLength)]
        public string Specialization { get; set; }

        [MaxLength(EntityConstants.MaxAddressLength)]
        public string Address { get; set; }

        [MaxLength(EntityConstants.MaxOfficeLocationLength)]
        public string OfficeLocation { get; set; }

        [MaxLength(EntityConstants.MaxImagePathLength)]
        public string ProfileImagePath { get; set; }

        public decimal Salary { get; set; }

        public bool IsFullTime { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }

        // Navigation Properties
        public virtual Department Department { get; set; }
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; } = new HashSet<InstructorSubject>();
        public virtual ICollection<InstructorQualification> Qualifications { get; set; } = new HashSet<InstructorQualification>();
        public virtual ICollection<InstructorSchedule> Schedules { get; set; } = new HashSet<InstructorSchedule>();
    }

}
