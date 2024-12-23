namespace School.Core.Dto.Student
{
    public class StudentDTO : BaseDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string NationalId { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string StudentId { get; set; }
        public StudentStatus Status { get; set; }
        public double? GPA { get; set; }
        public int TotalCredits { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<string> Subjects { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelation { get; set; }
    }
}
