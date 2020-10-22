using System.Threading.Tasks;
using System.Transactions;
using Core.Auth;
using Core.Dtos;
using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        private readonly ISecurityDataProvider _securityDataProvider;

        public CustomerService(IUserService userService, IRepository repository, ISecurityDataProvider securityDataProvider)
        {
            _userService = userService;
            _repository = repository;
            _securityDataProvider = securityDataProvider;
        }

        public async Task RegisterCustomer(CustomerRegistrationRequest request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var user = await _userService.RegisterUser(request);
                var customer = new Customer
                {
                    User = user,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    
                };
                await _repository.Insert(customer);
                await _repository.Save();
                scope.Complete();
            }
        }


        public async Task<CustomerDetails> GetCustomerDetails()
        {
            var currentUser = await _securityDataProvider.GetCurrentLoggedInUser();
            var customer = await _repository.GetQuery<Customer>(x => x.UserId == currentUser.Id).SingleOrDefaultAsync();
            return new CustomerDetails
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }
    }
}