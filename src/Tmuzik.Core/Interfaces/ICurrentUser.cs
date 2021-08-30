using System;
using Tmuzik.Core.Contract.Models;

namespace Tmuzik.Core.Interfaces
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        Guid? Id { get; }
        Guid? ProfileId { get; }
        string Email { get; }
        bool? Verified { get; }
        DateTime? CreationTime { get; }
        AuthUserProfile Profile { get; }
    }
}