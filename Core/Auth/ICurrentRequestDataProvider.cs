using Core.Models;
using System.Threading.Tasks;

namespace Core.Auth
{
    public interface ICurrentRequestDataProvider
    {
        string GetCurrentUserName();
        Task<User> GetCurrentRequestUser();
        Task<Customer> GetCurrentRequestCustomer();
    }
}
