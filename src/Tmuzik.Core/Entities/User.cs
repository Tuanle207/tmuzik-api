using System;
using System.Collections.Generic;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class User : Entity, IHaveAuthInfo, IHaveObjectAudit
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Salt { get; set; }
        public DateTime LastPasswordUpdatedAt { get; set; }
        public string RefreshPasswordCode { get; set; }
        public long RefreshPasswordCodeExpiredAt { get; set; }
        public bool Verified { get; set; }
        public DateTime LastUpdationTime { get; set; }
        public Guid LastUpdator { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorId { get; set; }

        public UserProfile Profile { get; set; }
        public ICollection<UserLogin> UserLogins { get; set; }

        public User()
        {
            CreationTime = LastUpdationTime = DateTime.UtcNow;
            LastUpdator = default;
            CreatorId = default;
            Verified = false;
        }
    }
}