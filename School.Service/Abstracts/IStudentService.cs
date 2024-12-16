namespace School.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddStudent(Student student);
        public Task<string> EditStudent(Student student);
        public Task<string> DeleteStudent(int id);
        Task<bool> IsStudentUnique(string email, string phone);
        Task<bool> IsEmailExistExcludeSelf(int id, string email);
        Task<bool> IsPhoneExistExcludeSelf(int id, string phone);
        Task<bool> DepartmentExists(int departmentId);
        Task<PaginatedList<Student>> GetQueryableStudentsAsync(int pageNumber, int pageSize);

    }
}
