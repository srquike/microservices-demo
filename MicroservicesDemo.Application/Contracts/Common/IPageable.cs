using MicroservicesDemo.Application.Contracts.Persistence;
using MicroservicesDemo.Domain;
using System.Linq.Expressions;

namespace MicroservicesDemo.Application.Contracts.Common
{
    public interface IPageable
    {
        IRepository Where(Expression<Func<UserEntity, bool>> expression);
        IRepository Order<TValue>(Expression<Func<UserEntity, TValue>> expression);
        IRepository Take(int count);
        IRepository Skip(int count);
    }
}
