using System;

namespace Tmuzik.Application.Dto.Users
{
    public class SignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
    }
}