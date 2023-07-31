using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request);
            await _repository.DeleteAsync(user);
        }
    }
}
