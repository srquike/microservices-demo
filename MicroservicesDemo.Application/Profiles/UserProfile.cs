using AutoMapper;
using MicroservicesDemo.Application.Features.Users.Commands.CreateUser;
using MicroservicesDemo.Application.Features.Users.Common;
using MicroservicesDemo.Application.Features.Users.Queries.GetUsers;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity to Dto
            CreateMap<UserEntity, UserDto>();

            // Command to Entity
            CreateMap<CreateUserCommand, UserEntity>();
        }
    }
}
