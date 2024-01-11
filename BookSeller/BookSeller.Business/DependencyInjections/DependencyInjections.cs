using BookSeller.DataAccess.Concrete.EntityFramework;

namespace BookSeller.Business.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IUserService, UserEntityManager>();
            services.AddScoped<ILoginService, LoginService>();
            return services;
        }
    }
}
