namespace School.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _students;
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }

      
    }
}
