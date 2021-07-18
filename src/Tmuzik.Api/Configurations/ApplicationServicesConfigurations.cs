using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Services.Dto;

namespace Tmuzik.Api.Configurations
{
    public static class ApplicationServicesConfigurations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.Scan(
                scan => scan.FromAssemblies(typeof(DummDto).GetTypeInfo().Assembly)
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }
    }
}