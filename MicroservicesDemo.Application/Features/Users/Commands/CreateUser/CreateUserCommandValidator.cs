using FluentValidation;

namespace MicroservicesDemo.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(cuc => cuc.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("User's name can't be empty or null.")
                .MaximumLength(50)
                .MinimumLength(3)
                .WithMessage("User's name should have at least 3 characters and a maximum of 50 characters.");
        }
    }
}
