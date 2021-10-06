using System;

namespace Tmuzik.Core.Contract.Models
{
    public class SimplePlaylist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public DateTime CreationTime { get; set; }
    }
}