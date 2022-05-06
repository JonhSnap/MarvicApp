using MarvicSolution.DATA.Common;
using MarvicSolution.Services.System.Helpers;
using MarvicSolution.Services.System.Users.Requests;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Services.System.Users.Validators;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Must declare DI in startup
        private readonly IUser_Service _userService;
        private readonly Jwt_Service _jwtService;
        public UserController(IUser_Service userService, Jwt_Service jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        // /api/user/register
        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] Register_Request rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool result = _userService.Register(rq);

                return Ok("Register success");
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        // /api/user/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login_Request rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // Kiem tra tai khoan
                var user = _userService.GetUserbyUserName(rq.UserName);
                if (user == null)
                    return BadRequest("User name does not exsist");
                // Kiem tra mat khau
                if (!BCrypt.Net.BCrypt.Verify(rq.Password, user.Password))
                    return BadRequest("Password incorrect");
                // Thiet lap thong tin cho user da login
                UserLogin.SetInfo(user);
                // Tao token theo JWT
                var jwt = _userService.Authenticate(rq, user);
                // Tao cookie
                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddHours(24)
                });
                return Ok(user);
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        // /api/user/get
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Guid id_User = ValidateUser();
                var user = _userService.GetUserbyId(id_User);
                if (user == null)
                    return BadRequest($"Cannot find user with id = {id_User}");

                return Ok(user);
            
        }

        // /api/user/logout
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok("Logout success");
        }

        // /api/user/update
        [HttpPut("Update")]
        public IActionResult Update(Update_User_Request rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = _userService.Update(rq);
                if (userId.Equals(Guid.Empty))
                    return BadRequest();
                return Ok("Update user success");
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        // /api/User/7a370bac-b796-454d-84cf-18c603102ca2
        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = _userService.Delete(Id);
                if (userId.Equals(Guid.Empty))
                    return BadRequest();
                return Ok("Delete user success");
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        // /api/user/recovery-password
        [HttpPut("recovery-password")]
        public IActionResult RecoveryPassword(RecoveryPassword_Request rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userId = _userService.RecoveryPassword(rq);
                if (userId.Equals(Guid.Empty))
                    return BadRequest();
                return Ok("Recovery password for user success");
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }

        private Guid ValidateUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                return Guid.Parse(token.Issuer);
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
    }
}
