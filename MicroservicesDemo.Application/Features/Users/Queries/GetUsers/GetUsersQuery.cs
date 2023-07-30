using MediatR;

namespace MicroservicesDemo.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<IList<UserViewModel>>
    {
    }
}
