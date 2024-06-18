using FluentValidation;
using LibraryManager.Application.Commands.CreateUser;


namespace LibraryManager.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("O campo nome é obrigatório");
            RuleFor(u => u.Email).EmailAddress().WithMessage("E-mail não válido");
        }
    }
}
