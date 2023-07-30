using FluentValidation;

namespace MicroservicesDemo.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(duc => duc.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("User's Id can't be empty or null.");
        }
    }
}
