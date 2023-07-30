using MediatR;

namespace MicroservicesDemo.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActivated { get; set; } = false;
    }
}
