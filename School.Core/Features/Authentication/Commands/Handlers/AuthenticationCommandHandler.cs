namespace School.Core.Features.Authentication.Commands.Handlers
{
    internal class AuthenticationCommandHandler : ResponseHandler, IRequestHandler<CreateUserCommand, Response<string>>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IMapper _mapper;

        public AuthenticationCommandHandler(
            IAuthenticationService authenticationService,
            IStringLocalizer<SharedResource> localizer,
            IMapper mapper)
            : base(localizer)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var applicationUser = _mapper.Map<ApplicationUser>(request._createDTO);

            var result = await _authenticationService.Create(applicationUser);

            if (result != ResponseMessages.SuccessMessage)
            {
                return BadRequest<string>(result);
            }
            
            return Created<string>(result);


        }
    }
}
