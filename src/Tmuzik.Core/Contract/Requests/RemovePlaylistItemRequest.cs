using System;
using System.Collections.Generic;

namespace Tmuzik.Core.Contract.Requests
{
    public class RemovePlaylistItemRequest
    {
        public List<Guid> Items { get; set; }
    }
}