using MicroservicesDemo.Domain.Common;

namespace MicroservicesDemo.Domain
{
    public class UserEntity : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public bool IsActivated { get; set; }
    }
}
