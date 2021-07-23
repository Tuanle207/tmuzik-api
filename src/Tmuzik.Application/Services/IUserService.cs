using System.Threading.Tasks;
using Tmuzik.Application.Dto.Users;

namespace Tmuzik.Application.Services
{
    public interface IUserService
    {
        Task<SignupResponse> Signup(SignupRequest input);
        Task<LoginReponse> Login(LoginRequest input);
    }
}