using System;

namespace Tmuzik.Common.Models
{
    public interface IHaveAuthInfo
    {
        string Email { get; set; }
        string Password { get; set; }
        string Token { get; set; }
        string Salt { get; set; }
        DateTime LastPasswordUpdatedAt { get; set; }
        string RefreshPasswordCode { get; set; }
        long RefreshPasswordCodeExpiredAt { get; set; }
        bool Verified { get; set; }
    }
}