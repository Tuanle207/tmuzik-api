using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Data;
using Tmuzik.Infrastructure.DependencyInjections;

namespace Tmuzik.Application.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable, IScopedDependency<IUnitOfWork>
    {
        private readonly AppDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private bool _disposed = false;

        
        private IUserRepository _users = null;
        
        public IUserRepository Users => 
            _users ?? (_users = _serviceProvider.GetRequiredService<IUserRepository>());

        
        public UnitOfWork(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _dbContext.Dispose();
            }
            this._disposed = true;
        }
    }
}