﻿using FluentValidation;
using LibraryManager.Application.Commands.UpdateBook;

namespace LibraryManager.Application.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Id).NotEmpty().WithMessage("O campo Id é obrigatório");
            RuleFor(b => b.Author).NotEmpty().WithMessage("O campo autor é obrigatório");
            RuleFor(b => b.Title).NotEmpty().WithMessage("O campo título é obrigatório");
            RuleFor(b => b.ISBN).NotEmpty().WithMessage("O campo ISBN é obrigatório");
            RuleFor(b => b.YearPublication).NotEmpty().WithMessage("O campo ano de publicação é obrigatório");
        }
    }
}
