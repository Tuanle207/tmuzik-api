using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Playlists
{
    public class UserPlaylistSpecification : Specification<Playlist>
    {
        public UserPlaylistSpecification(Guid creator)
        {
            Query
                .AsNoTracking()
                .Where(X => X.CreatorId == creator);
        }
    }
}