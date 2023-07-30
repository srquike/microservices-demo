using MicroservicesDemo.Domain.Common;
using System.Linq.Expressions;

namespace MicroservicesDemo.Application.Contracts.Persistence
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IQueryable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(Expression<Func<TKey, bool>> expression);

        IRepository<TEntity, TKey> Where(Expression<Func<TEntity, bool>> expression);
        IRepository<TEntity, TKey> Order<TValue>(Expression<Func<TEntity, TValue>> expression);
        IRepository<TEntity, TKey> Take(int count);
        IRepository<TEntity, TKey> Skip(int count);

        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
