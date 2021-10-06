using System;
using Ardalis.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Artists
{
    public class ArtistSpecification : Specification<Artist>
    {
        public ArtistSpecification(Guid userProfileId)
        {
            Query
                .Where(x => x.CreatorId == userProfileId);
                
        }
    }
}