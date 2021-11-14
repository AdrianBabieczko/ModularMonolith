using System.Runtime.CompilerServices;
using Confab.Shared.Abstractions;
using Confab.Shared.Infrastructure.Api;
using Confab.Shared.Infrastructure.Exceptions;
using Confab.Shared.Infrastructure.Postgres;
using Confab.Shared.Infrastructure.Services;
using Confab.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly:InternalsVisibleTo("Confab.Bootstrapper")]
namespace Confab.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddErrorHandling();
            services.AddPostgres();
            services.AddSingleton<IClock, UtcClock>();
            services.AddHostedService<AppInitializer>();
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            return services;
        }
        
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandling();
            app.UseRouting();

            return app;
        }

        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T: new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }

        private static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }
    }
}