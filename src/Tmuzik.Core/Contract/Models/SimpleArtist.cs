using System;

namespace Tmuzik.Core.Contract.Models
{
    public class SimpleArtist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}