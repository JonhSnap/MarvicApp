using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.System.Users.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Services
{
    public class User_Service : IUser_Service
    {
        private readonly UserManager<App_User> _userManager;
        private readonly SignInManager<App_User> _singInManager;
        private readonly RoleManager<App_Role> _roleManager;
        private readonly IConfiguration _config;
        public User_Service(UserManager<App_User> userManager, SignInManager<App_User> signInManager,
            RoleManager<App_Role> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }
        public async Task<string> Authenticate(Login_Request rq)
        {
            var user = await _userManager.FindByNameAsync(rq.UserName);
            if (user == null)
                return null;

            var result = await _singInManager.PasswordSignInAsync(user, rq.Password, rq.RememberMe, true);
            if (!result.Succeeded)
                return null;

            var roles = _userManager.GetRolesAsync(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FullName),
                new Claim(ClaimTypes.Role,string.Join(";", roles)), // danh sach cach nhau bang dau ";"
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(Register_Request rq)
        {
            var user = new App_User()
            {
                // Required prop
                FullName = rq.FullName,
                UserName = rq.UserName,
                Password = rq.Password,
                Email = rq.Email,
                PhoneNumber = rq.PhoneNumber,
                JobTitle = rq.JobTitle,
                Department = rq.Department,
                Organization = rq.Organization
            };

            var result = await _userManager.CreateAsync(user, rq.Password);
            if (result.Succeeded)
                return true; // Co the add them cac claim mong muon

            // Ghi log error result.Error (list)
            return false;
        }
    }
}
