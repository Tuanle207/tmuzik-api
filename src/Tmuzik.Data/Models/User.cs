using System;
using Tmuzik.Infrastructure.Data.Models;

namespace Tmuzik.Data.Models
{
    public class User : Entity, IHaveAuthInfo, IHaveObjectAudit
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string FacebookAccessToken { get; set; }
        public string GoogleAccessToken { get; set; }
        public DateTime LastPasswordUpdatedAt { get; set; }
        public string RefreshPasswordCode { get; set; }
        public long RefreshPasswordCodeExpiredAt { get; set; }
        public bool Verified { get; set; }
        public DateTime LastUpdationTime { get; set; }
        public Guid LastUpdator { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid? CreatorId { get; set; }

        public Profile Profile { get; set; }
    }
}