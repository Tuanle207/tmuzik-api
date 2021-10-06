using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Common.Models;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Interfaces.Services;
using Tmuzik.Core.Specifications.Identities;

namespace Tmuzik.Core.Services
{
    public class DashboardService : AppService, IDashboardService
    {
        public DashboardService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public async Task<GetSearchResultsResponse> GetSearchResultsAsync(GetSearchResultsRequest input,
            CancellationToken cancellationToken = default)
        {
            string keyword = input.Query;
            string[] categories = !String.IsNullOrEmpty(input.Category) ? input.Category.Split(",") : new string[]{};
            var pageModel = new PageModelRequest { PageIndex = input.PageIndex, PageSize = input.PageSize };
            var result = new GetSearchResultsResponse();

            var profileId = CurrentUser.ProfileId;

            foreach (var cat in categories)
            {
                if (cat == SearchCategory.User)
                {
                    var specWithPagination = new UserProfileSpecification(keyword, profileId, pageModel);
                    var specWithoutPagination = new UserProfileSpecification(keyword, profileId);
                    var selector = UnitOfWork.UserProfiles.CreateSelector(x => Mapper.Map<SimpleUserProfile>(x));
                    var users = await UnitOfWork.UserProfiles.ListAsync(specWithPagination, selector, cancellationToken);
                    var totalCount = await UnitOfWork.UserProfiles.CountAsync(specWithoutPagination, cancellationToken);
                    var usersPageModel = new PageModelResponse<SimpleUserProfile>
                    {
                        Items = users,
                        PageIndex = pageModel.PageIndex,
                        PageSize = Math.Min((int)users.Count, (int)pageModel.PageSize),
                        TotalCount = totalCount
                    };
                    
                    result.Users = usersPageModel;
                }
            }

            return result;
        }
    }
}