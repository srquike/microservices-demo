using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Application.Features.Users.Common;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<UserDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAsync();
            var users = results.ToList();

            return _mapper.Map<IList<UserDto>>(users);
        }
    }
}
