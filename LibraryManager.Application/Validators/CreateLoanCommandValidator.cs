using FluentValidation;
using LibraryManager.Application.Commands.CreateLoan;

namespace LibraryManager.Application.Validators
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(L => L.UserId).NotEmpty().WithMessage("O campo id do usuário é obrigatório");
            RuleFor(L => L.BookId).NotEmpty().WithMessage("O campo id do livro é obrigatório");
        }
    }
}
