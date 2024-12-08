namespace School.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _context.Students.Include(r=>r.Department).Include(s=>s.StudentSubjects).ThenInclude(s=>s.Subject).ToListAsync();
        }
    }
}
