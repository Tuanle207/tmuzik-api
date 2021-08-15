using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Identities
{
    public class UserLoginFilterSpecification : Specification<UserLogin>
    {
        public UserLoginFilterSpecification(string refreshToken, Guid userId)
        {
            Query
                .Where(x => x.RefreshToken == refreshToken)
                .Where(x => x.UserId == userId);
        }
    }
}