using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class FavouriteAlbum : Entity
    {
        public Guid AlbumId { get; set; }
        public Guid CreatorId { get; set; }

        public Album Album { get; set; }
        public UserProfile Creator { get; set; }
    }
}