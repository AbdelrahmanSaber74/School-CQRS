using Microsoft.EntityFrameworkCore;

namespace School.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Find(int id)
        {
            return await _studentRepository.FindAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsListAsync()
        {
            var studentQuery = _studentRepository.GetQueryable();

            return await studentQuery
                .Include(s => s.Department)
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ToListAsync();
        }



    }
}
