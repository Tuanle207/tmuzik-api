using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Infrastructure.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Expression<Func<T, bool>>[] CreateFilter(params Expression<Func<T, bool>>[] filter);
        Expression<Func<T, TResult>> CreateProjector<TResult>(Expression<Func<T, TResult>> projector);
        Task<TResult> GetOneAsync<TResult>(Expression<Func<T, bool>>[] filter, Expression<Func<T, TResult>> projector);
        Task<T> GetOneAsync(Expression<Func<T, bool>>[] filter, bool noTracking = true);
        Task<IEnumerable<TResult>> GetManyAsync<TResult>(Expression<Func<T, bool>>[] filter, Expression<Func<T, TResult>> projector);
        IQueryable<T> Filter(Expression<Func<T, bool>>[] filter, bool noTracking = true);
        IQueryable<TResult> Filter<TResult>(Expression<Func<T, bool>>[] filter, Expression<Func<T, TResult>> projector);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>>[] filter, bool noTracking = true);
        void Add(T entity);
        void AddMany(IEnumerable<T> entities);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddManyAsync(params T[] entities);
        void Update(T input);
        Task<T> UpdateAsync(T input);
        Task<T> FindAndUpdateAsync<TUpdateDto>(Guid id, TUpdateDto update);
        Task DeleteOne(Guid id);
        void DeleteOne(T entity);
        Task DeleteOneAsync(Guid id);
        Task DeleteOneAsync(T entity);
        Task DeleteMany(params Guid[] ids);
        Task DeleteManyAsync(params Guid[] ids);
        Task SaveChangeAsync();
    }
}