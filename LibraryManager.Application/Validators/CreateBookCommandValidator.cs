using FluentValidation;
using LibraryManager.Application.Commands.CreateBook;

namespace LibraryManager.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Author).NotEmpty().WithMessage("O campo autor é obrigatório");
            RuleFor(b => b.Title).NotEmpty().WithMessage("O campo título é obrigatório");
            RuleFor(b => b.ISBN).NotEmpty().WithMessage("O campo ISBN é obrigatório");
            RuleFor(b => b.YearPublication).NotEmpty().WithMessage("O campo ano de publicação é obrigatório");
            RuleFor(b => b.TotalQuantity).NotEmpty().WithMessage("O campo quantidade total é obrigatório");
            RuleFor(b => b.Price).NotEmpty().WithMessage("O campo preço é obrigatório");
        }
    }
}
