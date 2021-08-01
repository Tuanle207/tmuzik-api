using System;
using System.Threading.Tasks;
using Tmuzik.Application.Dto.Requests;
using Tmuzik.Application.Dto.Responses;
using Tmuzik.Infrastructure.Models;
using Tmuzik.Infrastructure.Services;

namespace Tmuzik.Application.Services
{
    public interface IUserService : IService
    {
        Task<SignupResponse> Signup(SignupRequest input);
        Task<LoginReponse> Login(LoginRequest input);
        Task<AuthDto> GetUserById(Guid id);
        Task<AuthDto> GetUserByEmail(string email);
        Task<bool> UserExists(string email);
    }
}