using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class FavouritePlaylist : Entity
    {
        public Guid PlaylistId { get; set; }
        public Guid CreatorId { get; set; }

        public Playlist Playlist { get; set; }
        public UserProfile Creator { get; set; }
    }
}