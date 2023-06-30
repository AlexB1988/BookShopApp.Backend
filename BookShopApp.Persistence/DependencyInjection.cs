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
    // TODO: Этот класс должен быть в каждом прожекте, где есть зависимости, например в апкликейшене AddApplication, и там в нем регаются все зависимости, например маппер, медиатор и тд
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["Db"];
            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: "BookApp");
                //options.UseNpgsql(connectionString, x => x.MigrationsAssembly("BookShopApp.WebApi"));
            });
            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            return services;
        }
    }
}
