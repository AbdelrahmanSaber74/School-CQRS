namespace School.Data.Entities
{
    public class Subject : BaseEntity
    {
        #region Constructors
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            InstructorSubjects = new HashSet<InstructorSubject>();
            SubjectMaterials = new HashSet<SubjectMaterial>();
        }
        #endregion

        #region Basic Properties
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string SubjectCode { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        #endregion

        #region Academic Properties
        public int CreditHours { get; set; }

        [Required]
        [StringLength(20)]
        public string Semester { get; set; }

        public AcademicYear AcademicYear { get; set; }

        public SubjectLevel Level { get; set; }

        public SubjectType Type { get; set; } = SubjectType.Mandatory;

        public int MaxCapacity { get; set; }

        public int CurrentEnrollment { get; set; }

        [Range(0, 100)]
        public int PassingGrade { get; set; } = 50;

        public bool IsActive { get; set; } = true;
        #endregion

        #region Schedule Properties
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [StringLength(50)]
        public string ClassRoom { get; set; }

        public DayOfWeek[] ClassDays { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        #endregion

        #region Prerequisites
        public int? PrerequisiteSubjectId { get; set; }

        [ForeignKey(nameof(PrerequisiteSubjectId))]
        public virtual Subject PrerequisiteSubject { get; set; }

        public virtual ICollection<Subject> DependentSubjects { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }

        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

        public virtual ICollection<SubjectMaterial> SubjectMaterials { get; set; }
        #endregion

        #region Computed Properties
        [NotMapped]
        public string FullSubjectInfo => $"{SubjectCode} - {Name}";

        [NotMapped]
        public bool HasAvailableSeats => CurrentEnrollment < MaxCapacity;

        [NotMapped]
        public string Schedule => $"{string.Join(", ", ClassDays)} {StartTime:hh\\:mm} - {EndTime:hh\\:mm}";
        #endregion

        #region Methods
        public bool CanEnroll(Student student)
        {
            if (!IsActive || !HasAvailableSeats)
                return false;

            if (PrerequisiteSubjectId.HasValue)
            {
                var prerequisitePassed = student.StudentSubjects
                    .Any(ss => ss.SubjectId == PrerequisiteSubjectId && ss.Grade >= PassingGrade);

                if (!prerequisitePassed)
                    return false;
            }

            return true;
        }

        public void UpdateEnrollmentCount()
        {
            CurrentEnrollment = StudentsSubjects?.Count ?? 0;
        }

        public bool IsScheduleConflicting(Subject other)
        {
            if (ClassDays.Intersect(other.ClassDays).Any())
            {
                return (StartTime <= other.EndTime && EndTime >= other.StartTime);
            }
            return false;
        }
        #endregion
    }
}
