using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IRepository<UserEntity, Guid> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<UserEntity, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request);
            var result = await _repository.CreateAsync(user);

            return result;
        }
    }
}
