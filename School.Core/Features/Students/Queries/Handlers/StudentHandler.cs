namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentsListQuery, Response<List<GetStudentsListDTO>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetStudentsListDTO>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListAsync();
            var mappedStudents = _mapper.Map<List<GetStudentsListDTO>>(students);
            return Success(mappedStudents);
        }
    }
}
