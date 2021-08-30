using System;
using Ardalis.Specification;
using Tmuzik.Common.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Audios
{
    public class AudioWithPaginationSpecification : Specification<Audio>
    {
        public AudioWithPaginationSpecification(PageModelRequest input)
        {
            var pageIndex = input.PageIndex ?? 1;
            var pageSize = input.PageSize ?? 10;

            Query
                .AsNoTracking()
                .Include(x => x.Artist)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize);
        }

        public AudioWithPaginationSpecification(PageModelRequest input, Guid userId)
        {
            var pageIndex = input.PageIndex ?? 1;
            var pageSize = input.PageSize ?? 10;

            Query
                .AsNoTracking()
                .Where(x => x.CreatorId == userId)
                .Include(x => x.Artist)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize);
        }
    }
}