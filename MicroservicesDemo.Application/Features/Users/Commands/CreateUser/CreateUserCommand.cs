using MediatR;

namespace MicroservicesDemo.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
    }
}
