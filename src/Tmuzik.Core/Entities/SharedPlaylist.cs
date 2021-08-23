using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class SharedPlaylist : Entity
    {
        public Guid CreatorId { get; set; }
        public Guid GrantedId { get; set; }
        public Guid PlaylistId { get; set; }
    }
}