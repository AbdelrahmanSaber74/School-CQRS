namespace School.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                          IRequestHandler<AddStudentCommand, Response<string>>,
                                          IRequestHandler<EditStudentCommand, Response<string>>,
                                          IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;
        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResource> localizer)
            : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request.Student);
            var result = await _studentService.AddStudent(studentEntity);

            return result == ResponseMessages.SuccessMessage
                ? Created(string.Empty, _localizer[ResourceKeys.StudentAddedSuccessfully])
                : BadRequest<string>(_localizer[ResourceKeys.AddStudentFailed]);
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.EditStudentDTO.studentId);

            if (student == null)
            {
                return NotFound<string>(_localizer[ResourceKeys.StudentNotFound]);
            }

            var studentEntity = _mapper.Map(request.EditStudentDTO, student);
            var result = await _studentService.EditStudent(studentEntity);

            return result == ResponseMessages.StudentUpdatedSuccessfully
                ? Success(string.Empty, _localizer[ResourceKeys.StudentUpdatedSuccessfully])
                : NotFound<string>(_localizer[ResourceKeys.StudentNotFound]);
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.DeleteStudent(request.StudentId);

            return result switch
            {
                ResponseMessages.SuccessDeleteMessage => Deleted<string>(),
                ResponseMessages.StudentNotFound => NotFound<string>(_localizer[ResourceKeys.StudentNotFound]),
                _ => BadRequest<string>(_localizer[ResourceKeys.DeleteStudentFailed])
            };
        }
    }
}