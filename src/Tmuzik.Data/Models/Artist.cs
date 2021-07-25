using System;
using Tmuzik.Infrastructure.Models;

namespace Tmuzik.Data.Models
{
    public class Artist : Entity, IHaveDescription, IHaveCreationAudit
    {
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
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }

        public User BelongsTo { get; set; }

        public Artist()
        {
            Verified = false;
            Plays = 0;
            Follows = 0;
        }
    }

    public class ArtistPhotos
    {
        public string[] Items { get; set; }
    }
}