using MarvicSolution.BackendApi.Constants;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.System.Helpers;
using MarvicSolution.Services.System.Users.Requests;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Register([FromBody] Register_Request rq)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool result = await _userService.Register(rq);

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

                // Tao token theo JWT
                var jwt = _userService.Authenticate(rq);
                // Tao cookie
                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddHours(24)
                });
                var user = _userService.GetUserbyUserName(rq.UserName);
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
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Guid id_User = ValidateUser();
                var user = await _userService.GetUserbyId(id_User);
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
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
