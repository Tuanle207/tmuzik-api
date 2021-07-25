using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tmuzik.Data;
using Tmuzik.Infrastructure.Models;
using Tmuzik.Infrastructure.Repositories;

namespace Tmuzik.Application.Repositories
{

    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
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

        public IQueryable<T> AsQueryable(bool noTracking = true)
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

        public async Task DeleteMany(params Guid[] ids)
        {
            try 
            {
                var entities = await GetManyAsync(ids);
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
                var entities = await GetManyAsync(ids);
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
                var entity = await GetOneAsync(id);
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
                var entity = await GetOneAsync(id);
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
                var entity = await GetOneAsync(id);
                entity.UpdateWith(update);
                await _dbContext.SaveChangesAsync();
                return entity;
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<T>> GetManyAsync(params Guid[] ids)
        {
            try 
            {
                return await _dbContext.Set<T>()
                    .Where(x => ids.Contains(x.Id))
                    .ToListAsync();
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<T>> GetManyAsync(params Expression<Func<T, bool>>[] predicates)
        {
            try 
            {
                var query = AsQueryable();
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
                return await query.ToListAsync();
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<T> GetOneAsync(Guid id)
        {
            try 
            {
                var query = AsQueryable(false);
                return await query.FirstOrDefaultAsync(x => x.Id == id);
            } 
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public async Task<T> GetOneAsync(params Expression<Func<T, bool>>[] predicates)
        {
            try 
            {
                var query = AsQueryable();
                foreach (var predicate in predicates)
                {
                    query = query.Where(predicate);
                }
                return await query.FirstOrDefaultAsync();

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

    }
}