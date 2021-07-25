using System.Threading.Tasks;
using Tmuzik.Application.Dto.Users;
using Tmuzik.Infrastructure.Services;

namespace Tmuzik.Application.Services
{
    public interface IUserService : IService
    {
        Task<SignupResponse> Signup(SignupRequest input);
        Task<LoginReponse> Login(LoginRequest input);
    }
}