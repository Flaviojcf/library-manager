using FluentValidation;
using LibraryManager.Application.Commands.LoginUser;

namespace LibraryManager.Application.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("E-mail não válido");
            RuleFor(u => u.Password).NotEmpty().WithMessage("O campo senha é obrigatório");
        }

    }
}
