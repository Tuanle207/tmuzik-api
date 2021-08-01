using System;

namespace Tmuzik.Application.Dto.Responses
{
    public class LoginReponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime Dob { get; set; }
        public string Token { get; set; }
    }
}