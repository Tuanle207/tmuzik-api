using System;
using Ardalis.Specification;
using Tmuzik.Common.Models;
using Tmuzik.Common.Specification;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Audios
{
    public class AudioWithPaginationSpecification : Specification<Audio>
    {
        public AudioWithPaginationSpecification(PageModelRequest input)
        {
            Query
                .AsNoTracking()
                .Include(x => x.Artist)
                .Paginate(input);

        }

        public AudioWithPaginationSpecification(PageModelRequest input, Guid userId)
        {
            Query
                .AsNoTracking()
                .Where(x => x.CreatorId == userId)
                .Include(x => x.Artist)
                .Paginate(input);
        }
    }
}