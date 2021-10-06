using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Follows
{
    public class UserFollowerSpecification : Specification<UserFollow>
    {
        public UserFollowerSpecification(Guid profileId)
        {
            Query.
                Where(x => x.FolloweeId == profileId);
        }
    }
}