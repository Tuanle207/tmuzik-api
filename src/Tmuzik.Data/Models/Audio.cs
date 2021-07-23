using System;
using Tmuzik.Infrastructure.Data.Models;

namespace Tmuzik.Data.Models
{
    public class Audio : Entity, IHaveDescription, IHaveCreationAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int Length { get; set; }
        public Guid Category { get; set; }
        public AudioGenere AudioGenere { get; set; }
        public int Plays { get; set; }
        public string AccessLevel { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }
        public Guid ArtistId { get; set; }


        public Artist Artist { get; set; }
        public User UploadedBy { get; set; }
    }

    public class AudioGenere 
    {
        public string[] Items { get; set; }
    }
}