using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class UserProfile : Entity
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public Guid UserId { get; set; }
        public bool IsPremium { get; set; }
        public bool IsArtist { get; set; }
    }
}