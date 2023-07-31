using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;
using MicroservicesDemo.Infrastructure.Persistence;

namespace MicroservicesDemo.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        private readonly UsersDbContext _context;

        public Repository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> CreateAsync(UserEntity user)
        {
            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception();
            }

            return user;
        }

        public async Task DeleteAsync(UserEntity user)
        {
            _context.Users.Remove(user);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception();
            }
        }

        public async Task UpdateAsync(UserEntity user)
        {
            _context.Users.Update(user);
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                throw new Exception();
            }
        }
        public Task<IReadOnlyList<UserEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
