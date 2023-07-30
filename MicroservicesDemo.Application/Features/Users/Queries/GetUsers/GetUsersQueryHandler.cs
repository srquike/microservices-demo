using AutoMapper;
using MediatR;
using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Features.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IList<UserViewModel>>
    {
        private readonly IRepository<UserEntity, Guid> _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IRepository<UserEntity, Guid> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAsync();
            var users = results.ToList();

            return _mapper.Map<IList<UserViewModel>>(users);
        }
    }
}
