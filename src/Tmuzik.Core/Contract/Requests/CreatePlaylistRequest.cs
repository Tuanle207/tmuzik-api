using Microsoft.AspNetCore.Http;

namespace Tmuzik.Core.Contract.Requests
{
    public class CreatePlaylistRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Cover { get; set; }
    }
}