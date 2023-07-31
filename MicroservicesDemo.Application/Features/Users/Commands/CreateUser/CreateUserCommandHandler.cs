using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Application.Features.Users.Common;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request);
            var result = await _repository.CreateAsync(user);
            var userCreated = _mapper.Map<UserDto>(result);

            return userCreated;
        }
    }
}
