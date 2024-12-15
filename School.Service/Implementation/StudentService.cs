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

        public async Task<bool> IsStudentUnique(string email, string phone)
        {
            return !await _studentRepository.ExistsAsync(r => r.Email == email || r.Phone == phone);
        }

        public async Task<bool> DepartmentExists(int departmentId)
        {
            return await _departmentRepository.ExistsAsync(d => d.Id == departmentId);
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

        public async Task<string> EditStudent(Student student)
        {
            try
            {
                // Find the student by ID
                var existingStudent = await _studentRepository.FindAsync(r => r.Id == student.Id);

                // If student not found, return an error message
                if (existingStudent == null)
                {
                    return ResponseMessages.StudentNotFound;
                }

                existingStudent.Name = student.Name ?? existingStudent.Name;
                existingStudent.Address = student.Address ?? existingStudent.Address;
                existingStudent.Phone = student.Phone ?? existingStudent.Phone;
                existingStudent.Email = student.Email ?? existingStudent.Email;


                await _studentRepository.UpdateAsync(existingStudent);

                // Return success message
                return ResponseMessages.StudentUpdatedSuccessfully;
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return ex.InnerException?.Message ?? ex.Message;
            }
        }

        public async Task<bool> IsEmailExistExcludeSelf(int id, string email)
        {
            var result = await _studentRepository.ExistsAsync(r => r.Email == email && r.Id != id);
            return result;
        }

        public async Task<bool> IsPhoneExistExcludeSelf(int id , string phone)
        {
            var result = await _studentRepository.ExistsAsync(r => r.Phone == phone && r.Id != id );
            return result;
        }
    }
}
