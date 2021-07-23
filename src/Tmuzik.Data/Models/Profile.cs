using System;

namespace Tmuzik.Data.Models
{
    public class Profile
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public Guid UserId { get; set; }
    }
}