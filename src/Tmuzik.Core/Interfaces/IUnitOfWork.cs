using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAsyncRepository<User> Users { get; }
        IAsyncRepository<UserProfile> UserProfiles { get; }
        IAsyncRepository<UserLogin> UserLogins { get; }
        IAsyncRepository<Artist> Artists { get; }
        IAsyncRepository<Audio> Audios { get; }
        IAsyncRepository<Album> Albums { get; }
        IAsyncRepository<AlbumItem> AlbumItems { get; }
        IAsyncRepository<Playlist> Playlists { get; }
        IAsyncRepository<PlaylistItem> PlaylistItems { get; }
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}