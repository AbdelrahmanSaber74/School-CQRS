namespace School.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string Gender { get; set; }

        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
