using MarvicSolution.Services.System.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Services
{
    public interface IUser_Service
    {
        Task<bool> Authenticate(Login_Request login_Requets);
        Task<bool> Register(Register_Request register_Request);
    }
}
