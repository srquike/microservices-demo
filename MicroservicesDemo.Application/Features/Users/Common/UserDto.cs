namespace MicroservicesDemo.Application.Features.Users.Common
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsActivated { get; set; }
    }
}
