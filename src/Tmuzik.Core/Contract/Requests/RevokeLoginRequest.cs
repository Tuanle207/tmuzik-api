using System;

namespace Tmuzik.Core.Contract.Requests
{
    public class RevokeLoginRequest
    {
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }
}