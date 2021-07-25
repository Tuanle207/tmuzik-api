namespace Tmuzik.Infrastructure.DependencyInjections
{
    public interface IScopedDependency : IDependency
    {
    }

    public interface IScopedDependency<T> : IDependency
    {
    }
}