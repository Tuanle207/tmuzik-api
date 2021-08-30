using System.Threading.Tasks;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAsyncRepository<User> Users { get; }
        IAsyncRepository<UserProfile> UserProfiles { get; }
        IAsyncRepository<UserLogin> UserLogins { get; }
        IAsyncRepository<Audio> Audios { get; }
        IAsyncRepository<Album> Albums { get; }
        IAsyncRepository<Playlist> Playlists { get; }
        Task CommitAsync();
    }
}