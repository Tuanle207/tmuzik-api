using System;

namespace Tmuzik.Core.Interfaces.Helpers
{
    public interface IAuthHelper
    {
        string GenerateAccessToken(string id);
        string GenerateRefreshToken();
        DateTime GetAccessTokenExpiryTime();
        (string, string) HashPassword(string password);
        Guid? ValidateToken(string token);
        bool VerifyPassword(string candidatePassword, string storedPasswordHashed, string salt);
    }
}