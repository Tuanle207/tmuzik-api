using System.Collections.Generic;
using Tmuzik.Core.Contract.Models;

namespace Tmuzik.Core.Contract.Responses
{
    public class GetUserProfileResponse
    {
        public UserInfo UserInfo { get; set; }
        public ICollection<SimplePlaylist> Playlists { get; set; }
        public ICollection<SimpleUserProfile> Followers { get; set; }
        public ICollection<SimpleUserProfile> Followings { get; set; }

        // For getting userinfo him/her-self
        public ICollection<AudioItem> Uploads { get; set; }
        public ICollection<AudioItem> RecentPlays { get; set; }
    }
}