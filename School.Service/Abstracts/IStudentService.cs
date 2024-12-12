namespace School.Service.Abstracts
{
    public interface IStudentService 
    {
        public Task<IEnumerable<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddStudent(Student student);

    }
}   
