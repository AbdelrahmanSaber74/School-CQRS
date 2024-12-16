namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                       IRequestHandler<GetStudentsListQuery, Response<IEnumerable<StudentDTO>>>,
                                       IRequestHandler<GetStudentByIdQuery, Response<StudentDTO>>,
                                       IRequestHandler<GetPaginatedStudentsListQuery, Response<PaginatedListDTO<StudentDTO>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<StudentDTO>>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsListAsync();
            var mappedStudents = _mapper.Map<IEnumerable<StudentDTO>>(students);
            return Success(mappedStudents);
        }

        public async Task<Response<StudentDTO>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);

            if (student == null)
            {
                return NotFound<StudentDTO>("Student Not Found");
            }

            var mappedStudent = _mapper.Map<StudentDTO>(student);
            return Success(mappedStudent);
        }

        public async Task<Response<PaginatedListDTO<StudentDTO>>> Handle(GetPaginatedStudentsListQuery request, CancellationToken cancellationToken)
        {
            // Fetch queryable students
            var paginatedStudents = await _studentService.GetQueryableStudentsAsync(request.PageNumber, request.PageSize);

            // Map to DTO
            var paginatedStudentsDto = _mapper.Map<PaginatedListDTO<StudentDTO>>(paginatedStudents);

            // Return response
            return Success(paginatedStudentsDto);
        }
    }
}
