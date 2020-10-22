using System.Threading.Tasks;
using Core.Dtos;
using Core.Models;

namespace Core.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<User> RegisterUser(CustomerRegistrationRequest request);
    }
}