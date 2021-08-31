using System;
using System.Collections.Generic;
using Tmuzik.Core.Contract.Models;

namespace Tmuzik.Core.Contract.Responses
{
    public class GetUserPlaylistDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public string Privacy { get; set; }
        public DateTime CreationTime { get; set; }
        public List<AudioItem> Items { get; set; }
    }
}