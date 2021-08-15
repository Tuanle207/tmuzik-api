using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class AlbumItem : Entity
    {
        public Guid AlbumId { get; set; }
        public Guid AudioId { get; set; }
        public Audio Audio { get; set; }
    }
}