using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Tmuzik.Core.Contract.Requests
{
    public class ClaimArtistRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Avatar { get; set; }
        public IFormFile Cover { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public List<IFormFile> Photos { get; set; }
        public List<IFormFile> Certificates { get; set; }
    }
}