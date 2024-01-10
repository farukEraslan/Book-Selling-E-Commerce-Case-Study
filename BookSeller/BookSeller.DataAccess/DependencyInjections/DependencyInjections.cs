namespace BookSeller.DataAccess.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryDAL, EFCategoryDAL>();
            services.AddScoped<IProductDAL, EFProductDAL>();
            return services;
        }
    }
}
