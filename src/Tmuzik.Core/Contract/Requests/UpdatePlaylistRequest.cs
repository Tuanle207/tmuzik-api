using System;
using Microsoft.AspNetCore.Http;

namespace Tmuzik.Core.Contract.Requests
{
    public class UpdatePlaylistRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Cover { get; set; }
    }
}