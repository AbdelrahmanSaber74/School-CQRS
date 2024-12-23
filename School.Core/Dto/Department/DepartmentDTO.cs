namespace School.Core.Dto.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DepartmentCode { get; set; }

        public string Description { get; set; }

        public string HeadOfDepartment { get; set; }

        public DateTime EstablishmentDate { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsAcceptingStudents { get; set; }

        public string Status { get; set; }

        public int CurrentStudentsCount { get; set; }

        public decimal Budget { get; set; }
    }
}

