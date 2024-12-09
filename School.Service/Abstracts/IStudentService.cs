namespace School.Service.Abstracts
{
    public interface IStudentService 
    {
        public Task<IEnumerable<Student>> GetStudentsListAsync();
        public Task<Student> Find(int id);

    }
}
