using MediatR;
using School.Core.Features.Students.Queries.Models;
using School.Data.Entities;
using School.Service.Abstracts;


namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : IRequestHandler<GetStudentsListQuery, List<Student>>
    {

        private readonly IStudentService _studentService;

        public StudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<List<Student>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentsListAsync();

        }
    }
}
