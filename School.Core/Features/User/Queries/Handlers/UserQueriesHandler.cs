namespace School.Core.Features.User.Queries.Handlers
{
    public class GetUserByEmailQueryHandler : ResponseHandler, IRequestHandler<GetUserByEmailQuery, Response<UserDTO>>
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IStringLocalizer<SharedResource> localizer, IUserService userService, IMapper mapper)
            : base(localizer)
        {
            _localizer = localizer;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Response<UserDTO>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null)
            {
                return NotFound<UserDTO>(_localizer[ResourceKeys.NotFound]);
            }

            var userDTO = _mapper.Map<UserDTO>(user);

            return Success(userDTO);
        }
    }
}
