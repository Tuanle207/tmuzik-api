using System;

namespace Tmuzik.Infrastructure.Services.Authorization
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