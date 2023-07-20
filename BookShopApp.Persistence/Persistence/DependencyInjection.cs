using BookShopApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShopApp.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Db"];

            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "BookApp");
                //options.UseNpgsql(connectionString, x => x.MigrationsAssembly("BookShopApp.Persistence"));
            });

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            return services;
        }
    }
}
