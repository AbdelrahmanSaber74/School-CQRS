namespace School.Core.Dto
{
    public class AddStudentDTO
    {

        public string Name { get; set; }

        public string Address { get; set; }

   
        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }
    }
}
