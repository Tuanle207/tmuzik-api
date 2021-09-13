using System;
using System.Collections.Generic;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Playlists
{
    public class PlaylistItemSpecification : Specification<PlaylistItem>
    {
        public PlaylistItemSpecification(List<Guid> ListId)
        {
            Query
                .Where(x => ListId.Contains(x.Id));
        }

         public PlaylistItemSpecification(List<Guid> ListAudioId, Guid playlistId)
        {
            Query
                .Where(x => x.PlaylistId == playlistId)
                .Where(x => ListAudioId.Contains(x.AudioId));
        }
    }
}