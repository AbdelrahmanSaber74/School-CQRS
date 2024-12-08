namespace School.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository  ;
        }

        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();


        }
    }
}
