using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryProject.DataAccess.Extension
{
    public static class DataAccessServiceRegistration
    {
        public static  IServiceCollection AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
                      options.UseSqlServer(configuration.GetConnectionString("SqlCon")));


            services.AddScoped<IBookDal, EfBookDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IAuthorDal, EfAuthorDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            return services;
        }

    }
}
