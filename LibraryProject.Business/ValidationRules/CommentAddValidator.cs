using FluentValidation;
using LibraryProject.Business.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.ValidationRules
{
    public class CommentAddValidator : AbstractValidator<AddCommentDto>
    {
        public CommentAddValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum içeriği boş olamaz.")
                .MaximumLength(500).WithMessage("Yorum 500 karakterden uzun olamaz.");

            // Manager'daki if(score < 1) kodunu buradan yönetiyoruz artık!
            RuleFor(x => x.Score)
                .InclusiveBetween(1, 5).WithMessage("Puan 1 ile 5 arasında olmalıdır.");
        }
    }
}