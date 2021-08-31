using System;

namespace Tmuzik.Core.Contract.Models
{
    public class Creator
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public bool IsArtist { get; set; }
    }
}