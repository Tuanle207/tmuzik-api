using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class AlbumSnapshot : Entity
    {
        public Guid AlbumId { get; set; }
        public int Plays { get; set; }
        public int Loves { get; set; }

        public Album Album { get; set; }
    }
}