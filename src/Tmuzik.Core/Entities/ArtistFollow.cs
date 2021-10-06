using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class ArtistFollow : Entity
    {
        public Guid ArtistId { get; set; }
        public Guid FollowerId { get; set; }

        public Artist Artist { get; set; }
        public UserProfile Follower { get; set; }
    }
}