using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Follows
{
    public class UserFollowingSpecification : Specification<UserFollow>
    {
        public UserFollowingSpecification(Guid profileId)
        {
            Query.
                Where(x => x.FollowerId == profileId);
        }
    }
}