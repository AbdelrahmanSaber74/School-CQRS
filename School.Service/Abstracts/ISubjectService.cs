namespace School.Service.Abstracts
{
    public interface ISubjectService
    {
        public Task<IEnumerable<Subject>> GetSubjectsListAsync();
        public Task<Student> Find(int id);

    }
}
