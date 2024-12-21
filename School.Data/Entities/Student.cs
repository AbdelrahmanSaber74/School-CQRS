namespace School.Data.Entities
{
    public class Student : BaseEntity
    {
        #region Constructors
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        #endregion

        #region Personal Information
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(20)]
        public string NationalId { get; set; }

        public string ProfilePicture { get; set; }
        #endregion

        #region Contact Information
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }
        #endregion

        #region Academic Information
        [Required]
        public DateTime EnrollmentDate { get; set; }

        [StringLength(20)]
        public string StudentId { get; set; }

        public StudentStatus Status { get; set; } = StudentStatus.Active;

        public AcademicLevel AcademicLevel { get; set; }

        public double? GPA { get; set; }

        public int TotalCredits { get; set; }

        [Required]
        public int DepartmentId { get; set; }
        #endregion

        #region Emergency Contact
        [StringLength(100)]
        public string EmergencyContactName { get; set; }

        [StringLength(20)]
        public string EmergencyContactPhone { get; set; }

        [StringLength(100)]
        public string EmergencyContactRelation { get; set; }
        #endregion

        #region Navigation Properties
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        public virtual ICollection<StudentAttendance> Attendances { get; set; }

        public virtual ICollection<StudentDocument> Documents { get; set; }
        #endregion

        #region Methods
        public bool CanEnrollInSubject(Subject subject)
        {
            return !StudentSubjects.Any(ss => ss.SubjectId == subject.Id) &&
                   Status == StudentStatus.Active;
        }

        public bool IsEligibleForGraduation()
        {
            return TotalCredits >= 120 && GPA >= 2.0;
        }
        #endregion
    }
}
