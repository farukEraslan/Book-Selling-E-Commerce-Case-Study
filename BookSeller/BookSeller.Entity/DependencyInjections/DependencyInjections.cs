namespace BookSeller.Entity.DependencyInjections
{
    public static  class DependencyInjections
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddScoped<AbstractValidator<UserCreateDTO>, UserCreateDTOValidator>();
            return services;
        }
    }
}
