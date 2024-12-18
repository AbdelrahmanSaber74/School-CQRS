namespace School.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                       IRequestHandler<GetStudentsListQuery, Response<IEnumerable<StudentDTO>>>,
                                       IRequestHandler<GetStudentByIdQuery, Response<StudentDTO>>,
                                       IRequestHandler<GetPaginatedStudentsListQuery, Response<PaginatedListDTO<StudentDTO>>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResource> localizer)
            : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
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
                return NotFound<StudentDTO>(_localizer[ResourceKeys.NotFound]);
            }

            var mappedStudent = _mapper.Map<StudentDTO>(student);
            return Success(mappedStudent);
        }

        public async Task<Response<PaginatedListDTO<StudentDTO>>> Handle(GetPaginatedStudentsListQuery request, CancellationToken cancellationToken)
        {
            var paginatedStudents = await _studentService.GetQueryableStudentsAsync(request.PageNumber, request.PageSize);
            var paginatedStudentsDto = _mapper.Map<PaginatedListDTO<StudentDTO>>(paginatedStudents);
            return Success(paginatedStudentsDto);
        }
    }
}