using Tmuzik.Data;
using Tmuzik.Data.Models;
using Tmuzik.Infrastructure.DependencyInjections;

namespace Tmuzik.Application.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IScopedDependency<IUserRepository>
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}