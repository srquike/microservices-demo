using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(request.Id);

            if (result == null)
            {
                throw new NullReferenceException(nameof(result));
            }

            var user = _mapper.Map(request, result);

            await _repository.UpdateAsync(user);
        }
    }
}
