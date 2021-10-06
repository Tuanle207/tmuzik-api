using System.Collections.Generic;
using Tmuzik.Common.Models;
using Tmuzik.Core.Contract.Models;

namespace Tmuzik.Core.Contract.Responses
{
    public class GetSearchResultsResponse
    {
        public PageModelResponse<SimpleUserProfile> Users { get; set; }
    }
}