using System;
using System.Collections.Generic;
using System.Text;
using Core.Auth;

namespace Core.Dtos
{

    public class LoginRequest
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class LoginResponse
    {

    }
    public class LoginSuccessResponse: LoginResponse
    {
        public AccessToken Token { get; set; }

        public string RefreshToken { get; set; }
    }

    public class LoginErrorResponse : LoginResponse
    {
        public string ErrorMessage { get; set; }
    }
}
