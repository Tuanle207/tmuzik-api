using System;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Data.Models
{
    public class AlbumItem : Entity
    {
        public Guid AlbumId { get; set; }
        public Guid AudioId { get; set; }
        public Audio Audio { get; set; }
    }
}