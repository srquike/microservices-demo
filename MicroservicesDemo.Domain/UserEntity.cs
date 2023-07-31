using MicroservicesDemo.Domain.Common;

namespace MicroservicesDemo.Domain
{
    public class UserEntity : BaseEntity
    {
        public string? Name { get; set; }
        public bool IsActivated { get; set; }
    }
}
