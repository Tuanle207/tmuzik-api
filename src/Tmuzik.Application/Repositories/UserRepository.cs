using Tmuzik.Data;
using Tmuzik.Data.Models;

namespace Tmuzik.Application.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}