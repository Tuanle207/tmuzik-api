using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class FavouriteAudio : Entity
    {
        public Guid AudioId { get; set; }
        public Guid CreatorId { get; set; }

        public Audio Audio { get; set; }
        public UserProfile Creator { get; set; }
    }
}