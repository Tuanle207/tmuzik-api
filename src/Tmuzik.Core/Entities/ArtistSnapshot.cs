using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class ArtistSnapshot : Entity
    {
        public Guid ArtistId { get; set; }
        public int Plays { get; set; }
        public int Loves { get; set; }

        public Artist Artist { get; set; }
    }
}