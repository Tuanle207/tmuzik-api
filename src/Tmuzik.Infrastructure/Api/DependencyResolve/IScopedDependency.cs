namespace Tmuzik.Infrastructure.Api.DependencyResolve
{
    public interface IScopedDependency : IDependency
    {
    }

    public interface IScopedDependency<T> : IDependency
    {
    }
}