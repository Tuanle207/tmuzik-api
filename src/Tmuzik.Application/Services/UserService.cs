using System;
using System.Threading.Tasks;
using AutoMapper;
using Tmuzik.Application.Dto.Users;
using Tmuzik.Application.Repositories;
using Tmuzik.Data.Models;
using Tmuzik.Infrastructure.Services.Authentication;

namespace Tmuzik.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public UserService(IMapper mapper, IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public Task<LoginReponse> Login(LoginRequest input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<SignupResponse> Signup(SignupRequest input)
        {
            if (input.Password != input.PasswordConfirm)
            {
                throw new Exception("400");
            }
            // ...

            var user = _mapper.Map<User>(input);
            _jwtHelper.TestDI();
            // user = await _userRepository.AddAsync(user);

            return new SignupResponse
            {
                Token = "test"
            };
        }
    }
}