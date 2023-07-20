using BookShopApp.Application.Common.Behaivvors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookShopApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavor<,>));
            services.AddScoped<Seed>();
            return services;
        }
    }
}
