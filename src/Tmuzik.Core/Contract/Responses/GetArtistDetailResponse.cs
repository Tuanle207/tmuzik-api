using System.Collections.Generic;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Contract.Responses
{
    public class GetArtistDetailResponse
    {
        public ArtistInfo Info { get; set; }
        public List<AudioItem> PopularAudios { get; set; }
        public List<Album> PopularAlbums { get; set; }
        public List<Album> Albums { get; set; }
    }
}