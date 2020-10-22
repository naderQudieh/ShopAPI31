using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Models;
using Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Core.Auth
{
    public class SecurityDataProvider : ISecurityDataProvider
    {
        private readonly IJwtTokenValidator _tokenValidator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthSettings _authSettings;
        private readonly IRepository _repository;

        public SecurityDataProvider(IJwtTokenValidator tokenValidator,
            IHttpContextAccessor httpContextAccessor,
            IOptions<AuthSettings> authSettings, IRepository repository)
        {
            _tokenValidator = tokenValidator;
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
            _authSettings = authSettings.Value;
        }
        public string GetCurrentUserName()
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", ""); ;
            var claimsPrincipal = _tokenValidator.GetPrincipalFromToken(accessToken, _authSettings.SecretKey);

            var userName = claimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                .Select(c => c.Value).SingleOrDefault();
            return userName;
        }

        public async Task<User> GetCurrentLoggedInUser()
        {
            var userName = GetCurrentUserName();
            return await _repository.Get<Models.User>(x => x.UserName == userName);
        }
    }
}