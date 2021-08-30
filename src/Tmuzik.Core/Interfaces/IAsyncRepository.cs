using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<int> CountAllAsync(CancellationToken cancellationToken = default);
        Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        // Query methods with projection
        Task<IReadOnlyList<TResult>> ListAllAsync<TResult>(Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);
        Task<TResult> FirstAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);
        Task<TResult> FirstOrDefaultAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default);
        Expression<Func<T, TResult>> CreateSelector<TResult>(Expression<Func<T, TResult>> projection);
    }
}