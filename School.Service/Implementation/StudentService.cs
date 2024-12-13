using Microsoft.EntityFrameworkCore;
using School.Data.Consts;

namespace School.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StudentService(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<string> AddStudent(Student student)
        {

            var studentExists = await _studentRepository.ExistsAsync(r => r.Phone == student.Phone || r.Email == student.Email);
            var DepartmentExists = await _departmentRepository.ExistsAsync(d => d.Id == student.DepartmentId);

            if (studentExists)
            {
                return ResponseMessages.AlreadyExistsMessage;

            }

            if (DepartmentExists == false)
            {
                return ResponseMessages.DepartmentNotFound;
            }


            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
            return ResponseMessages.SuccessMessage;

        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {

            var student = await _studentRepository.GetTableNoTracking()
                .Include(d => d.Department)
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);

            return student;

        }

        public async Task<IEnumerable<Student>> GetStudentsListAsync()
        {

            var students = await _studentRepository.GetTableNoTracking()
                .Include(d => d.Department)
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ToListAsync();

            return students;
        }



    }
}
