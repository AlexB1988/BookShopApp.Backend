using BookShopApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Db"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(connectionString, x => x.MigrationsAssembly("BookShopApp.WebApi"));
            });
            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            return services;
        }
    }
}
