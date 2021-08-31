using System;
using System.Collections.Generic;

namespace Tmuzik.Core.Contract.Requests
{
    public class AddPlaylistItemRequest
    {
        public List<Guid> Items { get; set; }
    }
}