using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tmuzik.Infrastructure.Data.Models;

namespace Tmuzik.Application.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> AsQueryable(bool noTracking = true);
        Task<T> GetOneAsync(Guid id);
        Task<T> GetOneAsync(params Expression<Func<T, bool>>[] predicates);
        Task<IEnumerable<T>> GetManyAsync(params Guid[] ids);
        Task<IEnumerable<T>> GetManyAsync(params Expression<Func<T, bool>>[] predicates);
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