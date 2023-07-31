using MicroservicesDemo.Domain;

namespace MicroservicesDemo.Application.Contracts.Common
{
    public interface IReadable
    {
        Task<IReadOnlyList<UserEntity>> GetAsync();
        Task<UserEntity> GetAsync(Guid id);
    }
}
