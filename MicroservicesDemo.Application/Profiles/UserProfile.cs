using AutoMapper;
using MicroservicesDemo.Application.Features.Users.Commands.CreateUser;
using MicroservicesDemo.Application.Features.Users.Commands.DeleteUser;
using MicroservicesDemo.Application.Features.Users.Commands.UpdateUser;
using MicroservicesDemo.Application.Features.Users.Common;
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
            CreateMap<DeleteUserCommand, UserEntity>();
            CreateMap<UpdateUserCommand, UserEntity>();
        }
    }
}