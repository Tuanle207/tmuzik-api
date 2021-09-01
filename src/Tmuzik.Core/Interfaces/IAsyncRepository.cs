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
        Task<ICollection<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<ICollection<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Add(T entity);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        void Delete(T entity);
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<int> CountAllAsync(CancellationToken cancellationToken = default);
        Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        // Query methods with selector
        Task<ICollection<TResult>> ListAllAsync<TResult>(Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Task<ICollection<TResult>> ListAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Task<TResult> FirstAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Task<TResult> FirstOrDefaultAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> selector, CancellationToken cancellationToken = default);
        Expression<Func<T, TResult>> CreateSelector<TResult>(Expression<Func<T, TResult>> selector);
    }
}