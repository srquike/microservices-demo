using MediatR;
using MicroservicesDemo.Application.Features.Users.Common;

namespace MicroservicesDemo.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
    }
}
