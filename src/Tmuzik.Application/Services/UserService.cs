using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tmuzik.Application.Dto.Requests;
using Tmuzik.Application.Dto.Responses;
using Tmuzik.Application.Repositories;
using Tmuzik.Data.Models;
using Tmuzik.Infrastructure.Models;
using Tmuzik.Infrastructure.Services.Authorization;

namespace Tmuzik.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly AuthHelper _authHelper;
        private readonly ICurrentUser _currentUser;
        private readonly ILogger<UserService> _logger;

        public UserService(ILogger<UserService> logger, IMapper mapper, 
            IUserRepository userRepository, AuthHelper authHelper, ICurrentUser currentUser)
        {
            _logger = logger;
            _authHelper = authHelper;
            _currentUser = currentUser;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<AuthDto> GetUserByEmail(string email)
        {
            var filter = _userRepository.CreateFilter(
                x => x.Email == email
            );
            var projector = _userRepository.CreateProjector(
                x => _mapper.Map<AuthDto>(x)
            );
            var result = await _userRepository.GetOneAsync(filter, projector);
                
            return result;
        }

        public async Task<AuthDto> GetUserById(Guid id)
        {
            var filter = _userRepository.CreateFilter(
                x => x.Id == id
            );
            var projector = _userRepository.CreateProjector(
                x => _mapper.Map<AuthDto>(x)
            );
            var result = await _userRepository.GetOneAsync(filter, projector);
                
            return result;
        }

        public async Task<LoginReponse> Login(LoginRequest input)
        {
            var filter = _userRepository.CreateFilter(
                x => x.Email == input.Email
            );

            var user = await _userRepository.GetOneAsync(filter);
            if (user == default)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            var valid = _authHelper.VerifyPassword(input.Password, user.Password, user.Salt);  
            if (!valid)
            {
                throw ExceptionBuilder.Exception(CoreExceptions.Unauthorized);
            }

            var result = _mapper.Map<LoginReponse>(user);

            result.Token = _authHelper.GenerateToken(result.Id.ToString());
            return result;
        }

        public async Task<SignupResponse> Signup(SignupRequest input)
        {

            var user = _mapper.Map<User>(input);

            (user.Password, user.Salt) = _authHelper.HashPassword(user.Password);

            user = await _userRepository.AddAsync(user);

            return new SignupResponse
            {
                // Token = _authHelper.GenerateToken(user.Id.ToString(), user.Salt)
            };
        }

        public async Task<bool> UserExists(string email)
        {
            var test = _currentUser.Test;
            _logger.LogInformation($"current user's email: {test}");
            var filter = _userRepository.CreateFilter(
                x => x.Email == email
            );
            var query = _userRepository.Filter(filter);
            return await query.AnyAsync();
        }
    }
}