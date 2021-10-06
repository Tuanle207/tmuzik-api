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
                .AsNoTracking()
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

        public PlaylistSpecification(Guid creatorId, string privacyLevel)
        {
            Query.AsNoTracking()
                .Where(x => x.CreatorId == creatorId);
            
            if (!String.IsNullOrEmpty(privacyLevel))
            {
                Query.Where(x => x.Privacy == privacyLevel);
            }
        }
    }
}