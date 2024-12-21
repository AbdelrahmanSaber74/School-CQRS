namespace School.Data.Entities;
public class Department : BaseEntity
{
    #region Constructors
    public Department()
    {
        Students = new HashSet<Student>();
        DepartmentSubjects = new HashSet<DepartmentSubject>();
        Instructors = new HashSet<Instructor>();
    }
    #endregion

    #region Basic Properties
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(20)]
    public string DepartmentCode { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [StringLength(100)]
    public string HeadOfDepartment { get; set; }

    public DateTime EstablishmentDate { get; set; }

    [StringLength(50)]
    public string Location { get; set; }

    public int Capacity { get; set; }

    [StringLength(100)]
    public string Email { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }
    #endregion

    #region Status Properties
    public bool IsAcceptingStudents { get; set; } = true;

    public DepartmentStatus Status { get; set; } = DepartmentStatus.Active;

    public int CurrentStudentsCount { get; set; }

    public decimal Budget { get; set; }
    #endregion

    #region Navigation Properties
    public virtual ICollection<Student> Students { get; set; }

    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; }

    public virtual ICollection<DepartmentResource> Resources { get; set; }

    public virtual ICollection<DepartmentAnnouncement> Announcements { get; set; }
    #endregion

    #region Methods
    public bool CanAcceptMoreStudents()
    {
        return IsAcceptingStudents && CurrentStudentsCount < Capacity;
    }

    public void UpdateStudentCount()
    {
        CurrentStudentsCount = Students?.Count ?? 0;
    }

    public bool HasSubject(int subjectId)
    {
        return DepartmentSubjects?.Any(ds => ds.SubjectId == subjectId) ?? false;
    }
    #endregion
}