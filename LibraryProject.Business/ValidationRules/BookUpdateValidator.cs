using FluentValidation;
using LibraryProject.Business.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.ValidationRules
{
    public class BookUpdateValidator :AbstractValidator<BookUpdateDto>
    {


        public BookUpdateValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Book title is required.")
                .MaximumLength(200).WithMessage("Book title must not exceed 200 characters.");
            RuleFor(b => b.Price)
                .GreaterThan(0).WithMessage("Book price must be greater than zero.");
            RuleFor(b => b.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be a positive integer.");
            RuleFor(b => b.AuthorId)
                .GreaterThan(0).WithMessage("Author ID must be a positive integer.");
        }
    }
}
