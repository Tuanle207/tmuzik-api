using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Contract.Responses
{
    public class GetUserPlaylistResponse : PageModelResponse<UserPlaylist>
    {
        
    }
    
    public class UserPlaylist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
    }
}