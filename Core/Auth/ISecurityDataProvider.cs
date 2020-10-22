using System.Threading.Tasks;
using Core.Models;

namespace Core.Auth
{
    public interface ISecurityDataProvider
    {
        string GetCurrentUserName();
        Task<User> GetCurrentLoggedInUser();
    }
}