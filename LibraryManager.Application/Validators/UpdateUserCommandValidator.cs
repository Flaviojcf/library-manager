using FluentValidation;
using LibraryManager.Application.Commands.UpdateUser;

namespace LibraryManager.Application.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("O campo nome é obrigatório");
            RuleFor(u => u.Email).EmailAddress().WithMessage("O campo email é obrigatório");
        }
    }
}
