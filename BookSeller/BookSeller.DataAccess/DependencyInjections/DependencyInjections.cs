namespace BookSeller.DataAccess.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<IProductDAL, EFProductDAL>();
            services.AddScoped<ICartDAL, EFCartDAL>();
            services.AddScoped<ICartLineDAL, EFCartLineDAL>();
            return services;
        }
    }
}
