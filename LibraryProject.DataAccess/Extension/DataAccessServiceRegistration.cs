using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.EntityFramework;
using LibraryProject.DataAccess.Interceptors; // 1. Bu using ekli olmalı (Sende zaten var)
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryProject.DataAccess.Extension
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditInterceptor>();
            services.AddDbContext<LibraryContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlCon"));


                var interceptor = serviceProvider.GetRequiredService<AuditInterceptor>();
                options.AddInterceptors(interceptor);
            });

            services.AddScoped<IBookDal, EfBookDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IAuthorDal, EfAuthorDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<ILoanDal, EfLoanDal>();

            return services;
        }
    }
}