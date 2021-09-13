using System;
using System.Collections.Generic;

namespace Tmuzik.Core.Contract.Models
{
    public class PlaylistDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public string Privacy { get; set; }
        public DateTime CreationTime { get; set; }
        public Creator Creator { get; set; }
        public List<AudioItem> Items { get; set; }
    }
}