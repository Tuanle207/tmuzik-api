using System;
using Ardalis.Specification;
using Tmuzik.Common.Models;

namespace Tmuzik.Common.Specification
{
    public static class SpecificationExtensions
    {
        public static ISpecificationBuilder<T> Paginate<T>(this ISpecificationBuilder<T> query, PageModelRequest page)
        {
            var pageIndex = page.PageIndex ?? 1;
            var pageSize = page.PageSize ?? 10;

            query = query.Skip(pageSize * (pageIndex - 1))
                .Take(pageSize);
                
            return query;
        }
    }
}