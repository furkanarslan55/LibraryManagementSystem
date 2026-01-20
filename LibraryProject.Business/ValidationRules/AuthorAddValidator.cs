using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LibraryProject.Business.DTOs.AuthorDtos;


namespace LibraryProject.Business.ValidationRules
{
    public class AuthorAddValidator : AbstractValidator<AuthorAddDto>
    {


        public AuthorAddValidator() { 
        
        
        RuleFor(a => a.FirstName).NotEmpty().WithMessage("Author first name cannot be empty.");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("Author last name cannot be empty.");



        }
    }
}
