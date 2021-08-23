using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Identities
{
    public class UserWithProfileSpecification : Specification<User>
    {
        public UserWithProfileSpecification(string email)
        {
            Query
                .Where(x => x.Email == email)
                .Include(x => x.Profile);
        }

        public UserWithProfileSpecification(Guid id)
        {
            Query
                .Where(x => x.Id == id)
                .Include(x => x.Profile);
        }
    }
}