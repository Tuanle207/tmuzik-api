using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tmuzik.Common.Consts;
using Tmuzik.Common.DependencyInjections;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Interfaces;
using Tmuzik.Infrastructure.Data;

namespace Tmuzik.Infrastructure.Authorization
{
    public class AccessPermissionManager : IAccessPermissionManager, IScopedDependency<IAccessPermissionManager>
    {
        private class Resource
        {
            public Guid Id { get; set; }
            public string Privacy { get; set; }
            public Guid CreatorId { get; set; }
        }
        private readonly AppDbContext _context;
        private readonly ICurrentUser _currentUser;

        public AccessPermissionManager(AppDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<bool> CheckUserAccessPermission(ResourceType resourceType, Guid resourceId)
        {
            var item = await GetResourceForChecking(resourceType, resourceId);

            if (item == null)
            {
                return false;
            }
            
            switch (item.Privacy)
            {
                case PrivacyLevel.Public:
                    return true;
                case PrivacyLevel.Private:
                    // TODO
                    return _currentUser.IsAuthenticated && item.CreatorId == _currentUser.ProfileId.Value;
                case PrivacyLevel.Following:
                    // TODO
                    return true;
                case PrivacyLevel.Follower:
                    // TODO
                    return true;
                default:
                    return false;
            }
        }

        private async Task<Resource> GetResourceForChecking(ResourceType resourceType, Guid id)
        {
            IQueryable<Resource> query = null;
            if (resourceType == ResourceType.Audio)
            {
                query = _context.Set<Audio>()
                .Where(x => x.Id == id)
                .Select(x => new Resource 
                { 
                    Id = x.Id, 
                    Privacy = x.Privacy, 
                    CreatorId = x.CreatorId 
                });
            }
            else if (resourceType == ResourceType.Playlist)
            {
                query = _context.Set<Playlist>()
                .Where(x => x.Id == id)
                .Select(x => new Resource 
                { 
                    Id = x.Id, 
                    Privacy = x.Privacy, 
                    CreatorId = x.CreatorId 
                });
            }
            else if (resourceType == ResourceType.Album)
            {
                query = _context.Set<Album>()
                .Where(x => x.Id == id)
                .Select(x => new Resource 
                { 
                    Id = x.Id, 
                    Privacy = x.Privacy, 
                    CreatorId = x.CreatorId 
                });
            }

            if (query == null)
            {
                return null;
            }

            var resource = await query.FirstOrDefaultAsync();
            return resource;
        }
    }
}