using System;

namespace Tmuzik.Infrastructure.Models
{
    public class AuthDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime Dob { get; set; }
    }
}