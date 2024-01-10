using BookSeller.Core.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
