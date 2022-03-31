using MarvicSolution.Services.System.Users.Requests;
using MarvicSolution.Services.System.Users.Services;
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
        private readonly IUser_Service _user_Service;
        public UserController(IUser_Service user_Service)
        {
            _user_Service = user_Service;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromForm] Login_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultToken = await _user_Service.Authenticate(rq);
            if (string.IsNullOrEmpty(resultToken))
                return BadRequest("UserName or Password is incorrect");

            return Ok(new { token = resultToken });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] Register_Request rq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _user_Service.Register(rq);
            if (!result)
                return BadRequest("Register is unsuccessful");

            return Ok();
        }

    }
}
