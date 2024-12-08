namespace School.Infrastructure.Abstracts
{
    public interface IStudentRepository
    {
        public Task<Student> GetByIdAsync(int id);
        public Task<List<Student>> GetStudentsListAsync();
    }
}
