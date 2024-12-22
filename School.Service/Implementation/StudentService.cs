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
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
            return ResponseMessages.SuccessMessage;

        }

        public async Task<bool> IsStudentUnique(string email, string phone, string nationalId)
        {
            return !await _studentRepository.ExistsAsync(r => r.Email == email || r.Phone == phone || r.NationalId == nationalId);
        }

        public async Task<bool> DepartmentExists(int departmentId)
        {
            return await _departmentRepository.ExistsAsync(d => d.Id == departmentId);
        }

        public async Task<Student> GetStudentByIdAsync(string studentId)
        {

            var student = await _studentRepository.GetTableNoTracking()
                .Include(d => d.Department)
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(x => x.StudentId == studentId);

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

        public async Task<string> EditStudent(Student student)
        {
            try
            {
                await _studentRepository.UpdateAsync(student);

                // Return success message
                return ResponseMessages.StudentUpdatedSuccessfully;
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return ex.InnerException?.Message ?? ex.Message;
            }
        }

        public async Task<bool> IsEmailExistExcludeSelf(string studentId, string email)
        {
            var result = await _studentRepository.ExistsAsync(r => r.Email == email && r.StudentId != studentId);
            return result;
        }

        public async Task<bool> IsPhoneExistExcludeSelf(string studentId, string phone)
        {
            var result = await _studentRepository.ExistsAsync(r => r.Phone == phone && r.StudentId != studentId);
            return result;
        }

        public async Task<string> DeleteStudent(string studentId)
        {
            try
            {
                var student = await _studentRepository.FindAsync(s => s.StudentId == studentId);

                if (student != null)
                {
                    await _studentRepository.DeleteAsync(student);
                    return ResponseMessages.SuccessDeleteMessage;
                }

                return ResponseMessages.StudentNotFound;
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.InnerException}";
            }
        }

        public async Task<PaginatedList<Student>> GetQueryableStudentsAsync(int pageNumber, int pageSize)
        {
            var queryableStudents = _studentRepository.GetQueryable()
                .Include(student => student.Department)
                .Include(student => student.StudentSubjects)
                    .ThenInclude(studentSubject => studentSubject.Subject);

            return PaginatedList<Student>.Create(queryableStudents, pageNumber, pageSize);
        }

    }
}
