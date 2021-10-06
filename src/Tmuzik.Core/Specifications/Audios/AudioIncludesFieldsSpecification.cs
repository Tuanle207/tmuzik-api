using System;
using System.Collections.Generic;
using Ardalis.Specification;
using Tmuzik.Common.Models;
using Tmuzik.Common.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Audios
{
    public class AudioIncludesFieldsSpecification : Specification<Audio>
    {
        public AudioIncludesFieldsSpecification(Guid audioId, bool tracking = false)
        {
            if (!tracking) 
            {
                Query.AsNoTracking();
            }

            Query
                .Where(x => x.Id == audioId)
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.UploadedBy);
        }

        public AudioIncludesFieldsSpecification(List<Guid> idList, bool tracking = false)
        {
            if (!tracking) 
            {
                Query.AsNoTracking();
            }

            Query
                .Where(x => idList.Contains(x.Id))
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.UploadedBy);
        }

        public AudioIncludesFieldsSpecification(PageModelRequest input)
        {
            Query
                .AsNoTracking()
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.UploadedBy)
                .Paginate(input);
        }

        public AudioIncludesFieldsSpecification(PageModelRequest input, Guid userId)
        {
            Query
                .AsNoTracking()
                .Where(x => x.CreatorId == userId)
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.UploadedBy)
                .Paginate(input);
        }

        public AudioIncludesFieldsSpecification(Guid creatorId, int? limit = null)
        {
            Query.AsNoTracking()
                .Where(x => x.CreatorId == creatorId)
                .Include(x => x.Album)
                .Include(x => x.Artist);

            if (limit != null)
            {
                Query.Take(limit ?? 10);
            }   
        }
    }
}