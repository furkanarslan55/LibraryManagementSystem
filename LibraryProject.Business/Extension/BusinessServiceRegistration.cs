using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.AutoMapper;
using LibraryProject.Business.Concrete;
using LibraryProject.Business.ValidationRules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Extension
{
    public static class BusinessServiceRegistration
    {

        public static IServiceCollection AddBusinessServices( this IServiceCollection services)
        {




            services.AddAutoMapper(typeof(MappingProfile));
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<BookAddValidator>();

          
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IAuthorService, AuthorManager>();
            return services;
        }
    }
}
