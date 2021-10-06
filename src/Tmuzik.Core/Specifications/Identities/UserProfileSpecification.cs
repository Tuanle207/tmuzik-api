using System;
using Ardalis.Specification;
using Tmuzik.Common.Models;
using Tmuzik.Common.Specification;
using Tmuzik.Core.Entities;

namespace Tmuzik.Core.Specifications.Identities
{
    public class UserProfileSpecification : Specification<UserProfile>
    {
        public UserProfileSpecification(Guid userId)
        {
            Query
                .AsNoTracking()
                .Where(x => x.UserId == userId);
        }

        public UserProfileSpecification(string name, Guid? currentProfileId, PageModelRequest page = null)
        {
            var trimmedNLowerKeyword = !string.IsNullOrEmpty(name) ? name.Trim().ToLower() : String.Empty;

            Query
                .AsNoTracking()
                .Where(x => x.Id != currentProfileId)
                .Where(x => String.IsNullOrEmpty(trimmedNLowerKeyword) ? true : x.FullName.ToLower().StartsWith(name));

            if (page != null)
            {
                Query.Paginate(page);
            }
        }
    }
}