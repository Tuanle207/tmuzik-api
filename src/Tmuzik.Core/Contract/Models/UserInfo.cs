using System;

namespace Tmuzik.Core.Contract.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
    }
}