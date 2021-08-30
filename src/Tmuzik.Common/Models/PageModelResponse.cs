using System.Collections.Generic;

namespace Tmuzik.Common.Models
{
    public class PageModelResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? TotalCount { get; set; }
    }
}