using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class SharedAlbum : Entity
    {
        public Guid CreatorId { get; set; }
        public Guid GrantedId { get; set; }
        public Guid AlbumId { get; set; }
    }
}