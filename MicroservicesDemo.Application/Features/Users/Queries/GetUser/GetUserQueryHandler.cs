using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Application.Features.Users.Common;

namespace MicroservicesDemo.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAsync(request.Id);
            var user = _mapper.Map<UserDto>(result);

            return user;
        }
    }
}
