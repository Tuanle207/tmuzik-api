using System;
using System.Collections.Generic;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Playlists
{
    public class PlaylistSpecification : Specification<Playlist>
    {
        public PlaylistSpecification(Guid playlistId)
        {
            Query
                .Where(x => x.Id == playlistId)
                .Include(x => x.Items)
                .ThenInclude(x => x.Audio)
                .ThenInclude(x => x.Album)
                .Include(x => x.Items)
                .ThenInclude(x => x.Audio)
                .ThenInclude(x => x.Artist)
                .Include(x => x.Items)
                .ThenInclude(x => x.Audio)
                .ThenInclude(x => x.UploadedBy);

        }
    }
}