using System;

namespace Tmuzik.Core.Contract.Models
{
    public class AuthUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
        public DateTime Dob { get; set; }
    }
}