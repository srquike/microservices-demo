using MicroservicesDemo.Application.Contracts.Common;

namespace MicroservicesDemo.Application.Contracts.Persistence
{
    public interface IRepository : IWriteable, IReadable // IPageable, IWriteable, IReadable
    {

    }
}
