namespace School.Core.Dto
{
    public class AddStudentDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
