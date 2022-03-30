using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.System.Users.Requests;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Services
{
    public class User_Service : IUser_Service
    {
        public User_Service(UserManager<App_User> userManager, SignInManager<App_User> signInManager)
        {

        }
        public Task<bool> Authenticate(Login_Request login_Requets)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(Register_Request register_Request)
        {
            throw new NotImplementedException();
        }
    }
}
