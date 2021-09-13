using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Playlists
{
    public class PlaylistItemsByPlaylistSpecification : Specification<PlaylistItem>
    {
        public PlaylistItemsByPlaylistSpecification(Guid playlistId)
        {
            Query
                .Where(x => x.PlaylistId == playlistId);
        }
    }
}