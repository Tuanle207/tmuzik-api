using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tmuzik.Common.Models;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : Entity
    {
        protected readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.CountAsync(cancellationToken);
        }

        public async Task<int> CountAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().CountAsync(cancellationToken);
        }


        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<TResult>> ListAllAsync<TResult>(Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>()
                .Where(x => true)
                .Select(projection)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec, projection);
            return await specificationResult.ToListAsync(cancellationToken);
        }

        public async Task<TResult> FirstAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec, projection);
            return await specificationResult.FirstAsync(cancellationToken);
        }

        public async Task<TResult> FirstOrDefaultAsync<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec, projection);
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }

        public Expression<Func<T, TResult>> CreateSelector<TResult>(Expression<Func<T, TResult>> projection)
        {
            return projection;
        }

        

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var specificationEvaluator = new SpecificationEvaluator();
            return specificationEvaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T> spec, Expression<Func<T, TResult>> projection)
        {
            var query = ApplySpecification(spec);
            return query.Select(projection);
        }
    }
}