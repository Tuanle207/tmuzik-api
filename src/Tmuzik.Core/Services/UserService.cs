using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Exceptions;
using Tmuzik.Core.Interfaces;
using Tmuzik.Core.Interfaces.Helpers;
using Tmuzik.Core.Interfaces.Services;
using Tmuzik.Core.Specifications.Identities;

namespace Tmuzik.Core.Services
{
    public class UserService : AppService, IUserService
    {
        private readonly IAuthHelper _authHelper;
        private readonly ILogger<UserService> _logger;
        private readonly IFbAuthService _fbAuthService;

        public UserService(IServiceProvider serviceProvider, ILogger<UserService> logger, 
            IAuthHelper authHelper,
            IFbAuthService fbAuthService)
        : base(serviceProvider)    
        {
            _logger = logger;
            _authHelper = authHelper;
            _fbAuthService = fbAuthService;
        }


        public async Task<LoginResponse> LoginAsync(LoginRequest input, CancellationToken cancellationToken = default)
        {
            var userSpec = new UserWithProfileSpecification(input.Email);

            var user = await UnitOfWork.Users.FirstOrDefaultAsync(userSpec, cancellationToken);
            if (user == default)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            var valid = _authHelper.VerifyPassword(input.Password, user.Password, user.Salt);  
            if (!valid)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            var result = new LoginResponse
            {
                Data = Mapper.Map<LoginResponseData>(user)
            };

            result.Token = await GrantLoginToken(user.Id);

            return result;
        }

        public async Task<RefreshLoginResponse> RefreshLoginSessionAsync(RefreshLoginRequest input, CancellationToken cancellationToken)
        {
            var userLoginSpec = new UserLoginFilterSpecification(input.RefreshToken, input.UserId);

            var userLogin = await UnitOfWork.UserLogins.FirstOrDefaultAsync(userLoginSpec, cancellationToken);

            if (userLogin == null)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            if (userLogin.ExpiryTime > DateTime.Now)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            var res = new RefreshLoginResponse
            {
                AccessTokenExpiresAt = _authHelper.GetAccessTokenExpiryTime(),
                AccessToken = _authHelper.GenerateAccessToken(userLogin.UserId.ToString())
            };

            return res;
        }

        public async Task<LoginResponse> LoginWithFacebookAsync(LoginWithFacebookRequest input, CancellationToken cancellationToken = default)
        {
            var validatedTokenResult = await _fbAuthService.ValidateAccessTokenAsync(input.FbAccessToken);
            if (!validatedTokenResult.Data.IsValid) {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            var userFbInfo = await _fbAuthService.GetUserInfoAsync(input.FbAccessToken);

            var userSpec = new UserWithProfileSpecification(userFbInfo.Email);
            var user = await UnitOfWork.Users.FirstOrDefaultAsync(userSpec, cancellationToken);
            
            if (user == null)
            {
                user = new User
                {
                    Email = userFbInfo.Email,
                    CreationTime = DateTime.Now
                };

                var createdUser = await UnitOfWork.Users.AddAsync(user, cancellationToken);

                var profile = await UnitOfWork.UserProfiles.AddAsync(new UserProfile
                {
                    FullName = userFbInfo.Name,
                    Avatar = userFbInfo.Picture.Data.Url.ToString(),
                    UserId = createdUser.Id,
                    // Dob = 
                });

                return new LoginResponse
                {
                    Token = await GrantLoginToken(createdUser.Id),
                    Data = new LoginResponseData
                    {
                        Id = createdUser.Id,
                        Email = createdUser.Email,
                        FullName = profile.FullName,
                        Avatar = profile.Avatar,
                        Dob = profile.Dob
                    }
                };
            }

            return new LoginResponse
            {
                Token = await GrantLoginToken(user.Id),
                Data = Mapper.Map<LoginResponseData>(user)
            };
        }

        public async Task<SignupResponse> SignupAsync(SignupRequest input, CancellationToken cancellationToken = default)
        {

            if (input.Password != input.PasswordConfirm)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.BadRequest, "Passwords did not match!");
            }

            var user = new User
            {
                CreationTime = DateTime.Now,
                Email = input.Email,
                Verified = false
            };
            
            (user.Password, user.Salt) = _authHelper.HashPassword(input.Password);

            user = await UnitOfWork.Users.AddAsync(user, cancellationToken);

            await UnitOfWork.UserProfiles.AddAsync(new UserProfile
            {
                UserId = user.Id,
                FullName = input.FullName,
                Dob = input.Dob,
            }, cancellationToken);

            return new SignupResponse
            {
                Message = "success"
            };
        }

        private async Task<LoginResponseToken> GrantLoginToken(Guid userId)
        {
            var refreshToken = _authHelper.GenerateRefreshToken();
            await UnitOfWork.UserLogins.AddAsync(new UserLogin
            {
                ExpiryTime = DateTime.Now.AddYears(1),
                RefreshToken = refreshToken,
                UserId = userId
            });

            return new LoginResponseToken
            {
                RefreshToken = refreshToken,
                AccessTokenExpiresAt = _authHelper.GetAccessTokenExpiryTime(),
                AccessToken = _authHelper.GenerateAccessToken(userId.ToString())
            };
        }
    }
}