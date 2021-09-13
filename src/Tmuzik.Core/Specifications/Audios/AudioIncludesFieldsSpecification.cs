using System;
using System.Collections.Generic;
using Ardalis.Specification;
using Tmuzik.Common.Models;
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
            var pageIndex = input.PageIndex ?? 1;
            var pageSize = input.PageSize ?? 10;
            var skip = pageSize * (pageIndex - 1);
            var take = pageSize;

            Query
                .AsNoTracking()
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.UploadedBy)
                .Skip(skip)
                .Take(take);
        }

        public AudioIncludesFieldsSpecification(PageModelRequest input, Guid userId)
        {
            var pageIndex = input.PageIndex ?? 1;
            var pageSize = input.PageSize ?? 10;
            var skip = pageSize * (pageIndex - 1);
            var take = pageSize;

            Query
                .AsNoTracking()
                .Where(x => x.CreatorId == userId)
                .Include(x => x.Album)
                .Include(x => x.Artist)
                .Include(x => x.UploadedBy)
                .Skip(skip)
                .Take(take);
        }
    }
}