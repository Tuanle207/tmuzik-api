using System;

namespace Tmuzik.Core.Contract.Models
{
    public class AudioItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ArtistTag { get; set; }
        public SimpleArtist Artist { get; set; }
        public string AlbumTag { get; set; }
        public SimpleAlbum Album { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string Privacy { get; set; }
        public string Cover { get; set; }
        public string File { get; set; }
        public DateTime CreationTime { get; set; }
        public Creator Creator { get; set; }
    }
}