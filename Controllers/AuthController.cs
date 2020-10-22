using System.Threading.Tasks;
using Core.Dtos;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace shopapi.Controllers
{
    /// <summary>
    /// Manages user
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Gets the token of a user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> GetToken(LoginRequest request)
        {
            var loginResponse = await _userService.Login(request);
            return Ok(loginResponse);
        }


    }
}
