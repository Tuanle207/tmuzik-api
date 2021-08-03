using System.Threading.Tasks;

namespace Tmuzik.Application.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CommitAsync();
        
    }
}