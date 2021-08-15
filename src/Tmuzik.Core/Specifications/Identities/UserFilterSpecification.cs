using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Identities
{
    public class UserFilterSpecification : Specification<User>
    {
        public UserFilterSpecification(string email)
        {
            Query
                .Where(x => x.Email == email);
        }
    }
}