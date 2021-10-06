using System;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;

namespace Tmuzik.Core.Interfaces.Services
{
    public interface IIdentityService : IAppService
    {
        Task<SignupResponse> SignupAsync(SignupRequest input, CancellationToken cancellationToken = default);
        Task<LoginResponse> LoginAsync(LoginRequest input, CancellationToken cancellationToken = default);
        Task<LoginResponse> LoginWithFacebookAsync(LoginWithFacebookRequest input, CancellationToken cancellationToken = default);
        Task<RefreshLoginResponse> RefreshLoginSessionAsync(RefreshLoginRequest input, CancellationToken cancellationToken = default);
        Task RevokeLoginSessionAsync(RevokeLoginRequest input, CancellationToken cancellationToken = default);
        Task<AuthUser> GetUserForApplicationAuthAsync(Guid id, CancellationToken cancellationToken = default);
        Task<GetUserProfileResponse> GetUserProfileAsync(Guid id, CancellationToken cancellationToken = default);
    }
}