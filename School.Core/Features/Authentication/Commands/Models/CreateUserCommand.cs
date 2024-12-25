namespace School.Core.Features.Authentication.Commands.Models
{
    public class CreateUserCommand : IRequest<Response<string>>
    {
        public CreateDTO _createDTO { get; set; }

        public CreateUserCommand(CreateDTO createDTO)
        {
            _createDTO = createDTO;
        }
    }
}
