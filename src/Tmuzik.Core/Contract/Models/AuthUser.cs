using System;

namespace Tmuzik.Core.Contract.Models
{
    public class AuthUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Verified { get; set; }
        public DateTime CreationTime { get; set; }
        public AuthUserProfile Profile { get; set; }
    }

    public class AuthUserProfile 
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public bool IsPremium { get; set; }
        public bool IsArtist { get; set; }
    }
}