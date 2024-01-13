using Microsoft.Extensions.DependencyInjection;

namespace BookSeller.Core.DependencyInjections
{
    public static class DependencyInjections
    {
        public static IServiceCollection CoreServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
