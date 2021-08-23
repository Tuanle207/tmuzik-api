using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class PlaylistItem : Entity
    {
        public Guid PlaylistId { get; set; }
        public Guid AudioId { get; set; }
        public Audio Audio { get; set; }
    }
}