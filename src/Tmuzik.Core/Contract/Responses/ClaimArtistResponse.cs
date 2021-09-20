using System;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Contract.Responses
{
    public class ClaimArtistResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string YoutubeUrl { get; set; }
        public ArtistPhotos Photo { get; set; }
        public bool Verified { get; set; }
        public int Plays { get; set; }
        public int Follows { get; set; }
    }
}