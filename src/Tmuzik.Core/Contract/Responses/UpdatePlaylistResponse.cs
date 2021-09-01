using System;

namespace Tmuzik.Core.Contract.Responses
{
    public class UpdatePlaylistResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
    }
}