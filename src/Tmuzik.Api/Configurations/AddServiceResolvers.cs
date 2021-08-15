using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Common.DependencyInjections;
using Tmuzik.Core;
using Tmuzik.Core.Interfaces;
using Tmuzik.Infrastructure.Data;

namespace Tmuzik.Api.Configurations
{
    public static partial class ServicesConfigurations
    {
        public static void AddAutoServiceResolvers(this IServiceCollection services)
        {
            
            var assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName.StartsWith("Tmuzik"))
                .Where(x => !x.FullName.Contains(".Tests"))
                .Where(x => !x.FullName.Contains(".Test"))
                .ToArray();

            AddServiced(services, assemblies);
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.Scan(
                scan => scan.FromAssemblies(typeof(DummyDto).Assembly)
                    .AddClasses(classes => classes.AssignableTo<IAppService>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }

        public static void AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.Scan(
                scan => scan.FromAssemblies(typeof(DummyDto).Assembly)
                    .AddClasses(classes => classes.AssignableTo(typeof(IAsyncRepository<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );
        }

        private static IServiceCollection AddServiced(IServiceCollection services, params Assembly[] assemblies)
        {

            var servicesToRegister = assemblies
                .SelectMany(x => x.GetTypes())
                .FilterTypes()
                .ToList();

            foreach (var serviceToRegister in servicesToRegister)
            {
                var (serviceType, implementationType) = GetTypes(serviceToRegister);

                var lifetime = GetLifetime(serviceToRegister);

                RegisterWithTypes(services, serviceType, implementationType, lifetime);
            }

            return services;
        }

        #region helpers & extension helpers
        private static void RegisterWithTypes(IServiceCollection services, 
            Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            var descriptor = new ServiceDescriptor(serviceType, implementationType, lifetime);

            services.Add(descriptor);
        }

        private static IEnumerable<Type> FilterTypes(this IEnumerable<Type> list, params Assembly[] assemblies)
        {
            Type[] types = 
            {  
               typeof(IDependency),
               typeof(ITransientDependency),
               typeof(IScopedDependency),
               typeof(ISingletonDependency),
               typeof(ITransientDependency<>),
               typeof(IScopedDependency<>),
               typeof(ISingletonDependency<>)
            };
            return list
                .Where(t => !types.Contains(t))
                .Where(t => (typeof(IDependency).IsAssignableFrom(t)))
                .ToList();
        }

        private static (Type serviceType, Type implementationType) GetTypes(Type serviceToRegister)
        {
            var genericInterface = serviceToRegister
                .GetInterfaces()
                .FirstOrDefault(x => x.IsGenericType && typeof(IDependency).IsAssignableFrom(x));


            return (genericInterface != null
                ? genericInterface.GetGenericArguments()[0]
                : serviceToRegister, serviceToRegister);
        }

        private static ServiceLifetime GetLifetime(Type serviceToRegister)
        {
            var lifetime = ServiceLifetime.Transient;

            if (typeof(IScopedDependency).IsAssignableFrom(serviceToRegister))
            {
                lifetime = ServiceLifetime.Scoped;
            }
            else if (typeof(ISingletonDependency).IsAssignableFrom(serviceToRegister))
            {
                lifetime = ServiceLifetime.Singleton;
            }

            return lifetime;
        }
        #endregion
    }
}