using Microsoft.EntityFrameworkCore;

namespace School.Service.Implementation
{
    public class SubjectsService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectsService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public Task<Student> Find(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Subject>> GetSubjectsListAsync()
        {

            return await _subjectRepository.GetAllAsync();




        }
    }
}
