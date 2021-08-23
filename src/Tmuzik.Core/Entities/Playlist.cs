using System;
using System.Collections.Generic;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class Playlist : Entity, IHaveDescription, IHaveCreationAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public string Privacy { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorId { get; set; }


        public UserProfile Creator { get; set; }
        public ICollection<PlaylistItem> Items { get; set; }
    }
}