using System;

namespace Tmuzik.Core.Contract.Responses
{
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiresAt { get; set; }
    }
}