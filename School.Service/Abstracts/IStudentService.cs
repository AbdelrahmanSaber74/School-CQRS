namespace School.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(string studentId);
        public Task<string> AddStudent(Student student);
        public Task<string> EditStudent(Student student);
        public Task<string> DeleteStudent(string studentId);
        Task<bool> IsStudentUnique(string email, string phone, string nationalId);
        Task<bool> IsEmailExistExcludeSelf(string studentId, string email);
        Task<bool> IsPhoneExistExcludeSelf(string studentId, string phone);
        Task<PaginatedList<Student>> GetQueryableStudentsAsync(int pageNumber, int pageSize);

    }
}
