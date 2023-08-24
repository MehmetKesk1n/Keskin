using MK.Business.Implementation;
using MK.Business.Interface;
using MK.Business.Profiles;
using MK.DataAccess.EF.Repositories;
using MK.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MK.Business
{
    public static class ServicesCollectionExtentions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookBs, BookBs>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryBs, CategoryBS>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBs, UserBs>();




            services.AddAutoMapper(typeof(BookProfile).Assembly);
            services.AddAutoMapper(typeof(CategoryProfile).Assembly);
            services.AddAutoMapper(typeof(UserProfile).Assembly);



        }
    }
}
