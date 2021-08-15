using System;
using Tmuzik.Common.Models;

namespace Tmuzik.Core.Entities
{
    public class UserLogin : Entity
    {
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiryTime { get; set; }
    }
}