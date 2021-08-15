using System;
using System.Collections.Generic;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class Album : Entity, IHaveDescription, IHaveCreationAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string AlbumCover { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }


        public Artist Artist { get; set; }
        public ICollection<AlbumItem> Items { get; set; }
    }
}