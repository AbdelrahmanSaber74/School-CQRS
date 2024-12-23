namespace School.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentsListAsyncQuery, Response<IEnumerable<DepartmentDto>>>,
                                                            IRequestHandler<GetDepartmentByIdAsyncQuery, Response<DepartmentDto>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper, IStringLocalizer<SharedResource> localizer) : base(localizer)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<IEnumerable<DepartmentDto>>> Handle(GetDepartmentsListAsyncQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentService.GetDepartmentsListAsync();

            if (departments == null || !departments.Any())
            {
                return NotFound<IEnumerable<DepartmentDto>>(_localizer[ResourceKeys.NoDepartmentsAvailable]);
            }

            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);


            var result = Success(departmentDtos);
            result.Meta = new { count = departmentDtos.Count() };
            return result;
        }

        public async Task<Response<DepartmentDto>> Handle(GetDepartmentByIdAsyncQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(request.Id);

            if (department == null)
            {
                return NotFound<DepartmentDto>(_localizer[ResourceKeys.NoDepartmentsAvailable]);
            }

            var departmentDtos = _mapper.Map<DepartmentDto>(department);

            return Success(departmentDtos);

        }
    }
}
