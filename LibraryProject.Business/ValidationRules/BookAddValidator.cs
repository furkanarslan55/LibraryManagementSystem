using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Business.DTOs.BookDtos;

namespace LibraryProject.Business.ValidationRules
{
    public class BookAddValidator : AbstractValidator<BookAddDto>
    {
        public BookAddValidator() { 
        
        
        
        RuleFor(b => b.Title).NotEmpty().WithMessage("Book title cannot be empty.");

            RuleFor(b => b.Price).GreaterThan(0).WithMessage("Book price must be greater than zero.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.")
                .NotEmpty().WithMessage("Fiyat boş geçilemez.");

            // Kategori Id kuralları
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçiniz.");


            RuleFor(x=> x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stok miktarı 0'dan küçük olamaz.");
        }
    }
}
