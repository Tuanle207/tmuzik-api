using System;

namespace Tmuzik.Core.Interfaces
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        Guid? Id { get; }
        string Email { get; }
        string FullName { get; }
        string Test { get; }
    }
}