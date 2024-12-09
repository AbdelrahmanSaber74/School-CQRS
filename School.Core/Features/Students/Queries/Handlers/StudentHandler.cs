namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentsListQuery, Response<IEnumerable<GetStudentsListDTO>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetStudentsListDTO>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListAsync();
            var mappedStudents = _mapper.Map<IEnumerable<GetStudentsListDTO>>(students);
            return Success(mappedStudents);
        }

      
    }
}
