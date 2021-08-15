using System.Threading.Tasks;
using Tmuzik.Core.Contract.Models;

namespace Tmuzik.Core.Interfaces
{
    public interface IFbAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfoResult> GetUserInfoAsync(string accessToken);
    }
}