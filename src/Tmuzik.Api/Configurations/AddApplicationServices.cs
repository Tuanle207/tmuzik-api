using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Services.Dto;

namespace Tmuzik.Api.Configurations
{
    public static partial class ServicesConfigurations
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.Scan(
                scan => scan.FromAssemblies(typeof(DummyDto).GetTypeInfo().Assembly)
                    .AddClasses()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }
    }
}