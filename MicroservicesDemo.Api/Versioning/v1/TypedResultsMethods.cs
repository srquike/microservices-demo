using MediatR;
using MicroservicesDemo.Application.Contracts.Infrastructure;
using MicroservicesDemo.Application.Features.Users.Commands.CreateUser;
using MicroservicesDemo.Application.Features.Users.Commands.DeleteUser;
using MicroservicesDemo.Application.Features.Users.Commands.UpdateUser;
using MicroservicesDemo.Application.Features.Users.Queries.GetUser;
using MicroservicesDemo.Application.Features.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesDemo.Api.Versioning.v1
{
    public static class TypedResultsMethods
    {
        public static async Task<IResult> GetAllUsersAsync(IMediator mediator)
        {
            var query = new GetUsersQuery();
            var users = await mediator.Send(query);

            return TypedResults.Ok(users);
        }

        public static async Task<IResult> CreateUserAsync([FromBody] CreateUserCommand command, IMediator mediator, IMessageProducer producer)
        {
            var user = await mediator.Send(command);

            producer.SendMessage(user);

            return TypedResults.Ok(user);
        }

        public static async Task<IResult> UpdateUserAsync([FromBody] UpdateUserCommand command, IMediator mediator)
        {
            await mediator.Send(command);

            return TypedResults.NoContent();
        }

        public static async Task<IResult> DeleteUserAsync(string id, IMediator mediator)
        {
            var command = new DeleteUserCommand()
            {
                Id = Guid.Parse(id)
            };

            await mediator.Send(command);

            return TypedResults.NoContent();
        }

        public static async Task<IResult> GetUserById(string id, IMediator mediator)
        {
            var query = new GetUserQuery()
            {
                Id = Guid.Parse(id)
            };

            var user = await mediator.Send(query);

            return TypedResults.Ok(user);
        }
    }
}
