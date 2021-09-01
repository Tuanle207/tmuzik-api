using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Tmuzik.Common.DependencyInjections;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Interfaces;

namespace Tmuzik.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable, IScopedDependency<IUnitOfWork>
    {
        private readonly AppDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private bool _disposed = false;

        private IAsyncRepository<User> _users;
        private IAsyncRepository<UserProfile> _userProfiles;
        private IAsyncRepository<UserLogin> _userLogins;
        private IAsyncRepository<Audio> _audios;
        private IAsyncRepository<Album> _albums;
        private IAsyncRepository<AlbumItem> _albumItems;
        private IAsyncRepository<Playlist> _playlists;
        private IAsyncRepository<PlaylistItem> _playlistItems;

        
        public UnitOfWork(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public IAsyncRepository<User> Users =>
            _users ?? (_users = _serviceProvider.GetRequiredService<IAsyncRepository<User>>());
        public IAsyncRepository<UserProfile> UserProfiles =>
            _userProfiles ?? (_userProfiles = _serviceProvider.GetRequiredService<IAsyncRepository<UserProfile>>());
        public IAsyncRepository<UserLogin> UserLogins =>
            _userLogins ?? (_userLogins = _serviceProvider.GetRequiredService<IAsyncRepository<UserLogin>>());
        public IAsyncRepository<Audio> Audios =>
            _audios ?? (_audios = _serviceProvider.GetRequiredService<IAsyncRepository<Audio>>());
        public IAsyncRepository<Album> Albums =>
            _albums ?? (_albums = _serviceProvider.GetRequiredService<IAsyncRepository<Album>>());
        public IAsyncRepository<AlbumItem> AlbumItems =>
            _albumItems ?? (_albumItems = _serviceProvider.GetRequiredService<IAsyncRepository<AlbumItem>>());
        public IAsyncRepository<Playlist> Playlists =>
            _playlists ?? (_playlists = _serviceProvider.GetRequiredService<IAsyncRepository<Playlist>>());
        public IAsyncRepository<PlaylistItem> PlaylistItems =>
            _playlistItems ?? (_playlistItems = _serviceProvider.GetRequiredService<IAsyncRepository<PlaylistItem>>());

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
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