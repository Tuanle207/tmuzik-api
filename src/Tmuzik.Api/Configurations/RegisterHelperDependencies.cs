using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Infrastructure.Api.DependencyResolve;
using Tmuzik.Infrastructure.Services.Authentication;

namespace Tmuzik.Api.Configurations
{
     public static partial class ServicesConfigurations
    {
        public static void RegisterHelperDependencies(this IServiceCollection services)
        {
            
            RegisterWithLifetime<ITransientDependency>(services, typeof(JwtHelper).Namespace);
            RegisterWithLifetime<IScopedDependency>(services);
            RegisterWithLifetime<ISingletonDependency>(services);
            RegisterInterfaceWithLifetime<ITransientDependency>(services);
            RegisterInterfaceWithLifetime<IScopedDependency>(services);
            RegisterInterfaceWithLifetime<ISingletonDependency>(services);
            
        }

        private static void RegisterWithLifetime<T>(IServiceCollection services, string namespaceName = null)
        {
            services.Scan(scan => 
            { 
                var entryAssembly = Assembly.GetEntryAssembly();
                var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
                var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
                var lifeTimeSelector = scan.FromAssemblies(assemblies)
                    .AddClasses()
                    .AsSelf();
                if (typeof(T) == typeof(ITransientDependency))
                {
                    lifeTimeSelector.WithTransientLifetime();
                } else if (typeof(T) == typeof(IScopedDependency))
                {
                    lifeTimeSelector.WithScopedLifetime();
                } else if (typeof(T) == typeof(ISingletonDependency))
                {
                    lifeTimeSelector.WithSingletonLifetime();
                }
            });
        }

        private static void RegisterInterfaceWithLifetime<T>(IServiceCollection services, string namespaceName = null)
        {
            services.Scan(scan => 
            { 
                var entryAssembly = Assembly.GetEntryAssembly();
                var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
                var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);
                var lifeTimeSelector = scan.FromAssemblies(assemblies)
                    .AddClasses()
                    .AsImplementedInterfaces();
                if (typeof(T) == typeof(ITransientDependency))
                {
                    lifeTimeSelector.WithTransientLifetime();
                } else if (typeof(T) == typeof(IScopedDependency))
                {
                    lifeTimeSelector.WithScopedLifetime();
                } else if (typeof(T) == typeof(ISingletonDependency))
                {
                    lifeTimeSelector.WithSingletonLifetime();
                }
            });
        }
    }
}