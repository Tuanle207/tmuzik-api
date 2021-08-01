using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Infrastructure.Repositories
{

    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            try 
            {
                _dbContext.Set<T>().Add(entity);
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            try 
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public void AddMany(IEnumerable<T> entities)
        {
            try 
            {
                foreach (var entity in entities)
                {
                    Add(entity);
                }
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<T>> AddManyAsync(params T[] entities)
        {
            try 
            {
                foreach (var entity in entities)
                {
                    Add(entity);
                }
                await _dbContext.SaveChangesAsync();
                return entities.ToList();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public Expression<Func<T, bool>>[] CreateFilter(params Expression<Func<T, bool>>[] filter)
        {
            return filter;
        }

        public Expression<Func<T, TResult>> CreateProjector<TResult>(Expression<Func<T, TResult>> projector)
        {
            return projector;
        }

        public async Task DeleteMany(params Guid[] ids)
        {
            try 
            {
                var filter = CreateFilter(x => ids.Contains(x.Id));
                var entities = await GetManyAsync(filter);
                foreach (var entity in entities)
                {
                    _dbContext.Set<T>().Remove(entity);
                }
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task DeleteManyAsync(params Guid[] ids)
        {
            try 
            {
                var filter = CreateFilter(x => ids.Contains(x.Id));
                var entities = await GetManyAsync(filter);
                foreach (var entity in entities)
                {
                    _dbContext.Set<T>().Remove(entity);
                }
                await _dbContext.SaveChangesAsync();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task DeleteOne(Guid id)
        {
            try 
            {
                var filter = CreateFilter(x => x.Id == id);
                var entity = await GetOneAsync(filter);
                _dbContext.Set<T>().Remove(entity);
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public void DeleteOne(T entity)
        {
            try 
            {
                _dbContext.Set<T>().Remove(entity);
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task DeleteOneAsync(Guid id)
        {
            try 
            {
                var filter = CreateFilter(x => x.Id == id);
                var entity = await GetOneAsync(filter);
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task DeleteOneAsync(T entity)
        {
            try 
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>>[] filter, bool noTracking = true)
        {
            try 
            {
                var query = AsQueryable(noTracking);
                foreach (var predicate in filter)
                {
                    query = query.Where(predicate);
                }

                return query;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public IQueryable<TResult> Filter<TResult>(Expression<Func<T, bool>>[] filter, Expression<Func<T, TResult>> projector)
        {
            try 
            {
                var query = AsQueryable();
                foreach (var predicate in filter)
                {
                    query = query.Where(predicate);
                }

                return query.Select(projector);
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Find entity and id and update. Please use this with performance warning!!! 
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <param name="update">The object that contains property need to be updated</param>
        /// <typeparam name="TUpdateDto">Type of object that contains property need to be updated</typeparam>
        /// <returns></returns>
        public async Task<T> FindAndUpdateAsync<TUpdateDto>(Guid id, TUpdateDto update)
        {
            try 
            {
                var filter = CreateFilter(x => x.Id == id);
                var entity = await GetOneAsync(filter);
                _dbContext.Set<T>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<TResult>> GetManyAsync<TResult>(Expression<Func<T, bool>>[] filter, Expression<Func<T, TResult>> projector)
        {
            try 
            {
                var query = AsQueryable();
                foreach (var predicate in filter)
                {
                    query = query.Where(predicate);
                }

                var result = await query
                    .Select(projector)
                    .ToListAsync();

                return result;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>>[] filter, bool noTracking = true)
        {
            try 
            {
                var query = AsQueryable(noTracking);
                foreach (var predicate in filter)
                {
                    query = query.Where(predicate);
                }
                
                var result = await query
                    .ToListAsync();

                return result;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<T, bool>>[] filter, Expression<Func<T, TResult>> projector)
        {
            try 
            {
                var query = AsQueryable();
                foreach (var predicate in filter)
                {
                    query = query.Where(predicate);
                }

                var result = await query
                    .Select(projector)
                    .FirstOrDefaultAsync();

                return result;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>>[] filter, bool noTracking = true)
        {
            try 
            {
                var query = AsQueryable(noTracking);
                foreach (var predicate in filter)
                {
                    query = query.Where(predicate);
                }

                var result = await query
                    .FirstOrDefaultAsync();

                return result;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task SaveChangeAsync()
        {
            try 
            {
                await _dbContext.SaveChangesAsync();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public void Update(T input)
        {
            try 
            {
                _dbContext.Set<T>().Update(input);
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<T> UpdateAsync(T input)
        {
            try 
            {
                _dbContext.Set<T>().Update(input);
                await _dbContext.SaveChangesAsync();
                return input;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        protected IQueryable<T> AsQueryable(bool noTracking = true)
        {
            try 
            {
                return noTracking 
                    ? _dbContext.Set<T>().AsNoTracking().AsQueryable()
                    : _dbContext.Set<T>().AsQueryable();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }
    }
}