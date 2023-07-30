using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IRepository<UserEntity, Guid> _repository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IRepository<UserEntity, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request);
            var result = await _repository.DeleteAsync(user);

            return result;
        }
    }
}
