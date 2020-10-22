using System.Threading.Tasks;
using Core.Auth;
using Core.Dtos;
using Core.Exceptions;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly IRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;


        public UserService(IJwtFactory jwtFactory, ITokenFactory tokenFactory, IRepository repository, IPasswordHasher<User> passwordHasher)
        {
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _repository.Get<User>(x => x.UserName == request.UserName);
            if (user != null)
            {
                if (_passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) !=
                    PasswordVerificationResult.Success)
                {
                    throw new UnAuthorizedExceptions("Invalid Password entered");
                }
                // generate refresh token
                var refreshToken = _tokenFactory.GenerateToken();
                // generate access token
                var generateEncodedToken = await _jwtFactory.GenerateEncodedToken(user.Id.ToString(), user.UserName);
                return new LoginSuccessResponse()
                {
                    Token = generateEncodedToken,
                    RefreshToken = refreshToken
                };
            }

            return new LoginErrorResponse
            {
                ErrorMessage = "No user found"
            };
        }

        public  async Task<User> RegisterUser(CustomerRegistrationRequest request)
        {
            // Check if the username already exists
            var hasAlreadyExistingUser = await _repository.Any<User>(x => x.UserName == request.MobileNumber);
            if (!hasAlreadyExistingUser)
            {
                var hashedPassword =  _passwordHasher.HashPassword(new User(), request.Password);
                var user = new User
                {
                    UserName = request.MobileNumber,
                    Email = request.Email,
                    Password = hashedPassword
                };
                await _repository.Insert(user);
               await _repository.Save();
               return user;
            }

            throw new InValidInputException("UserName already exists");

        }
    }
}
