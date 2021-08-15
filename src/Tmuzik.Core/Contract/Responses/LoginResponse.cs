using System;

namespace Tmuzik.Core.Contract.Responses
{
    public class LoginResponse
    {
        public LoginResponseToken Token { get; set; }
        public LoginResponseData Data { get; set; }
    }

    public class LoginResponseToken : AccessTokenResponse
    {
        public string RefreshToken { get; set; }
    }

    public class LoginResponseData 
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime Dob { get; set; }
    } 
}