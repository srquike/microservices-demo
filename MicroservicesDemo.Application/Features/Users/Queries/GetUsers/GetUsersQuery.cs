using MediatR;
using MicroservicesDemo.Application.Features.Users.Common;

namespace MicroservicesDemo.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<IReadOnlyList<UserDto>>
    {
    }
}
