using System;
using System.Threading.Tasks;
using Tmuzik.Common.Consts;

namespace Tmuzik.Core.Interfaces
{
    public interface IAccessPermissionManager
    {
        Task<bool> CheckUserAccessPermission(ResourceType resourceType, Guid resourceId);
    }
}