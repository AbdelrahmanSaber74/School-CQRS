namespace School.Core.Dto
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<string> Subjects { get; set; }
    }
}
