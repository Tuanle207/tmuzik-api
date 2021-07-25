namespace Tmuzik.Infrastructure.Api.DependencyResolve
{
    public interface ISingletonDependency : IDependency
    {
    }

    public interface ISingletonDependency<T> : IDependency
    {
    }
}