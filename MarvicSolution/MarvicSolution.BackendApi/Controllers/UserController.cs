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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            bool result = await _userService.Register(rq);

            return Ok("Register success");
        }

        // /api/user/login
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Tao token theo JWT
            var jwt = _userService.Authenticate(rq);
            // Tao cookie
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok("Login success");
        }

        // /api/user/get
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                Guid id_User = ValidateUserById();
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

        private Guid ValidateUserById()
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
