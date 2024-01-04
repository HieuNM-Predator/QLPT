using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.AuthRequest;
using QLPT_API.Services.IService;

namespace QLPT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("/api/auth/login")]
        public IActionResult Login(Request_Login request)
        {
            var result = _authService.Login(request);
            if (result == null)
            {
                return Unauthorized(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/auth/renew_token")]
        public IActionResult RenewToken(TokenDTO token)
        {
            var result = _authService.RenewAccessToken(token);
            if (result == null)
            {
                return Unauthorized(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/auth/register")]
        public IActionResult Register([FromForm]Request_Register request) 
        {

            return Ok(_authService.Register(request));
        }

        [HttpPost]
        [Route("/api/auth/confirm_active_account")]
        public IActionResult ConfirmActiveAccount(Request_ConfirmActiveAccount request)
        {
            return Ok(_authService.ConfirmActiveAccount(request));
        }

        [HttpPost]
        [Route("/api/auth/forgot_password")]
        public IActionResult ForgotPassword(Request_ForgotPassword request)
        {
            return Ok(_authService.ForgotPasword(request));
        }

        [HttpPost]
        [Route("/api/auth/confirm_create_newPassword")]
        public IActionResult ConfirmCreateNewPassword(Request_ConfirmCreateNewPassword request)
        {
            return Ok(_authService.ConfirmCreateNewPassword(request));
        }

        [HttpPost]
        [Route("/api/auth/change_password")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ChangePassword(Request_ChangePassword request)
        {
            if (!int.TryParse(HttpContext.User.FindFirst("Id")?.Value, out int id))
            {
                return BadRequest("Id người dùng không hợp lệ");
            }
            var result = _authService.ChangePassword(id, request);
            if (result == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
