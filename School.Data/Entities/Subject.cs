namespace School.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public DateTime Period { get; set; }

        public int CreditHours { get; set; }

        public string Semester { get; set; }

        public int? PrerequisiteSubjectId { get; set; }

        [ForeignKey(nameof(PrerequisiteSubjectId))]
        public virtual Subject PrerequisiteSubject { get; set; }

        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }

        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        public string FullSubjectInfo => $"{Code} - {Name}";
    }
}
