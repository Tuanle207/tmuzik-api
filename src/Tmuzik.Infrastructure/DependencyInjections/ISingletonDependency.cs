namespace Tmuzik.Infrastructure.DependencyInjections
{
    public interface ISingletonDependency : IDependency
    {
    }

    public interface ISingletonDependency<T> : IDependency
    {
    }
}