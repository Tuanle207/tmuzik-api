using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class Audio : Entity, IHaveDescription, IHaveCreationAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public AudioGenre Genre { get; set; }
        public int Plays { get; set; }
        public int Loves { get; set; }
        public string Privacy { get; set; }
        public bool FromArtist { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorId { get; set; }
        public string Artists { get; set; }
        public Guid? ArtistId { get; set; }


        public Artist Artist { get; set; }
        public UserProfile UploadedBy { get; set; }

        public Audio()
        {
            FromArtist = false;
            ArtistId = null;
            CreationTime = DateTime.UtcNow;
        }
    }

    public class AudioGenre 
    {
        public string[] Items { get; set; }
    }
}