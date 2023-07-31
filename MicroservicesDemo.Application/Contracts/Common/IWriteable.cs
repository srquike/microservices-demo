using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Contracts.Common
{
    public interface IWriteable
    {
        Task<UserEntity> CreateAsync(UserEntity entity);
        Task UpdateAsync(UserEntity entity);
        Task DeleteAsync(UserEntity entity);
    }
}
