using System.Threading.Tasks;
using Tmuzik.Core.Entities;

namespace Tmuzik.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> CheckUserExistsByEmailAsync(string email);
    }
}