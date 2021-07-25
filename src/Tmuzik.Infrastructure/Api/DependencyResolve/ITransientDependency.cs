namespace Tmuzik.Infrastructure.Api.DependencyResolve
{
    public interface ITransientDependency : IDependency
    {   
    }
    public interface ITransientDependency<T> : IDependency
    {   
    }
}