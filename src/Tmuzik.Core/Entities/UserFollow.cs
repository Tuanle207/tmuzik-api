using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class UserFollow : Entity
    {
        public Guid FolloweeId { get; set; }
        public Guid FollowerId { get; set; }

        public UserProfile Follower { get; set; }
        public UserProfile Followee { get; set; }
    }
}