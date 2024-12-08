namespace School.Data.Entities;
public class Department
{
    public Department()
    {
        Students = new HashSet<Student>();
        DepartmentSubjects = new HashSet<DepartmentSubject>();
    }

    public int Id { get; set; }

    [Required]
    [StringLength(500)]
    public string Name { get; set; }

    public virtual ICollection<Student> Students { get; set; }

    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
}
