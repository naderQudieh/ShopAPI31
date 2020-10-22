using System.Threading.Tasks;
using Core.Dtos;

namespace Core.Services
{
    public interface ICustomerService
    {
        Task RegisterCustomer(CustomerRegistrationRequest request);
        Task<CustomerDetails> GetCustomerDetails();
    }
}